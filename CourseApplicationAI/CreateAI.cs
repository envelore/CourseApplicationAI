using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseApplicationAI
{
    public partial class CreateAI : Form
    {
        public CreateAI(Panel map)
        {
            InitializeComponent();

            this.map = map;
            Action goDown = new Action("идти вниз", "", "", null, 0, -1); actions.Add(goDown);
            Action goUp = new Action("идти вверх", "", "", null, 0, 1); actions.Add(goUp);
            Action goRight = new Action("идти вправо", "", "", null, -1, 0); actions.Add(goRight);
            Action goLeft = new Action("идти вправо", "", "", null, 1, 0); actions.Add(goLeft);
            Action stop = new Action("остановиться", "", "", null, 0, 0); actions.Add(stop);

            tableViewActions.DataSource = actions;
            tableViewFactors.DataSource = factors;
            tableViewActionsFactors.DataSource = ideas;
            tableViewParam.DataSource = parametrs;
            generateIdeaList();
        }

        int currentPanel = 0;
        public BindingList<Image> imagesAI;
        public BindingList<Action> actions = new BindingList<Action>();
        public BindingList<Parametr> parametrs = new BindingList<Parametr>();
        public BindingList<Factor> factors = new BindingList<Factor>();
        public BindingList<Idea> ideas = new BindingList<Idea>();
        public Panel map;

        private void ButtonAddFactor_Click(object sender, EventArgs e)
        {
            tableEditor view = new tableEditor(this);
            view.source = tableViewFactors;
            //view.creator = this;
            view.Show();
        }

        private void TableViewParam_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnParamDelete.Enabled = true;
        }

        private void BtnParamDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in tableViewParam.SelectedCells)
            {
                if (cell.RowIndex == -1) return;
            }
            if ((tableViewParam.CurrentRow != null))
            {
                tableViewParam.Rows.Remove(tableViewParam.CurrentRow);
            }
        }

        private void BtnAddParam_Click(object sender, EventArgs e)
        {
            (tableViewParam.DataSource as BindingList<Parametr>).Add(new Parametr("", 0));
        }

        private void ButtonDeleteFactor_Click(object sender, EventArgs e)
        {
            if ((tableViewFactors.CurrentRow != null))
            {
                factors.Remove(tableViewFactors.CurrentRow.DataBoundItem as Factor);
            }
        }

        private void ButtonPickPathImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openpath = new FolderBrowserDialog();
            openpath.ShowDialog();
            var imagesPath = openpath.SelectedPath;
            try
            {
                pbActionDown.ImageLocation = imagesPath + "\\действиевниз.gif";
                pbActionUp.ImageLocation = imagesPath + "\\действиевверх.gif";
                pbActionLeft.ImageLocation = imagesPath + "\\действиевлево.gif";
                pbActionRight.ImageLocation = imagesPath + "\\действиевправо.gif";
                pbGoUp.ImageLocation = imagesPath + "\\вверх.gif";
                pbGoDown.ImageLocation = imagesPath + "\\вниз.gif";
                pbGoLeft.ImageLocation = imagesPath + "\\влево.gif";
                pbGoRight.ImageLocation = imagesPath + "\\вправо.gif";
                pbStatic.ImageLocation = imagesPath + "\\статик.gif";
                buttonForward.Enabled = true;
            } catch {
                MessageBox.Show("Не все изображения были найдены!");
            }
        }

        private void TableViewActions_SelectionChanged(object sender, EventArgs e)
        {
            if (tableViewActions.CurrentRow.Index < 5)
            {
                btnDeleteAction.Enabled = false;
            }
            else
            {
                btnDeleteAction.Enabled = true;
            }
        }

        private void BtnAddAction_Click(object sender, EventArgs e)
        {
            AddAction addAction = new AddAction(this);
            addAction.Show();
            generateIdeaList();
        }

        private void BtnDeleteAction_Click(object sender, EventArgs e)
        {
            tableViewActions.Rows.Remove(tableViewActions.CurrentRow);
            generateIdeaList();
            //(tableViewActions.DataSource as List<Action>).RemoveAt(tableViewActions.CurrentRow.Index);
            //tableViewActions.DataSource = actions;
        }

        public void generateIdeaList()
        {
            BindingList<Idea> newideas = new BindingList<Idea>();
            foreach (var act in actions)
            {
                Idea newIdea = new Idea(act, null);
                newideas.Add(newIdea);
            }
            ideas = newideas;
            tableViewActionsFactors.DataSource = ideas;
        }

        private void BtnAddActionDescription_Click(object sender, EventArgs e)
        {
            if (tableViewActionsFactors.CurrentRow.Cells[1] as DataGridViewTextBoxCell != null)
            {
                MessageBox.Show((tableViewActionsFactors.CurrentRow.Cells[1] as DataGridViewTextBoxCell).Value as string);
                Idea act = ideas.First<Idea>(a => a.name == (tableViewActionsFactors.CurrentRow.Cells[1] as DataGridViewTextBoxCell).Value as string);
                IdeasBaseForm form = new IdeasBaseForm(this, act, tableViewActionsFactors.CurrentRow);
                form.Show();
            }
        }

        private void ButtonForward_Click(object sender, EventArgs e)
        {
            if (currentPanel < 5)
                currentPanel++;
            else
            {
                AI bot = new AI(Convert.ToInt32(nUDX.Value),
                    Convert.ToInt32(nUDY.Value),
                    map,
                    pbActionDown.Image,
                    pbActionUp.Image,
                    pbActionLeft.Image,
                    pbActionRight.Image,
                    pbGoUp.Image,
                    pbGoDown.Image,
                    pbGoLeft.Image,
                    pbGoRight.Image,
                    pbStatic.Image,
                    actions,
                    parametrs,
                    factors,
                    ideas);
                bot.show();
                bot.smartLife();
                this.Close();
            }
        }
    }
}

public class Parametr
{
    public string name { get; set; }
    public int value { get; set; }

    public Parametr(string n, int val)
    {
        name = n;
        value = val;
    }
}

public class Factor
{
    public string name { get; set; }
    public string type { get; set; }
    public string nameOfComparedParametr;
    public string typeCompare; // >, < or =
    public int valueOfCompare;
    public string actionName;
    public string whatDoesImageAISee;
    public int distanceWatch;
    public string direction;
    public string nameOfAction;

    public Factor(string name, string type, object[] parametrs)
    {
        this.name = name;
        this.type = type;
        switch (type)
        {
            case "watching":
                whatDoesImageAISee = parametrs[0] as string;
                distanceWatch = Convert.ToInt32(parametrs[1]);
                direction = parametrs[2] as string;
                break;
            case "compare":
                nameOfComparedParametr = parametrs[0] as string;
                typeCompare = parametrs[1] as string;
                valueOfCompare = Convert.ToInt32(parametrs[2]);
                break;
            case "actionAvailable":
                nameOfAction = parametrs[0] as string;
                break;
        }
    } 
}

public class Action
{
    public string name { get; set; }
    public int xDistanceSubject;
    public int yDistanceSubject;
    public int xDistanceObject;
    public int yDistanceObject;
    public List<(Parametr, int)> changesOfParametrs;
    public string changesImage;
    public string actionImage;
    public Action(string name, string actionimg, string changesimg, List<(Parametr, int)> changes, int deltax, int deltay)
    {
        this.name = name;
        actionImage = actionimg;
        changesImage = changesimg;
        changesOfParametrs = changes;
        xDistanceObject = deltax;
        yDistanceObject = deltay;
    }
}

public class Idea
{
    public Action action;
    public List<(Factor, int)> weights;
    public string name { get; set; }

    public Idea(Action act, List<(Factor, int)> weights)
    {
        action = act; this.weights = weights;
        name = act.name;
    }

}

class AI
{
    int x;
    int y;
    public /*ref*/ Panel map;
    Image actionDown;
    Image actionUp;
    Image actionLeft;
    Image actionRight;
    Image goUp;
    Image goDown;
    Image goLeft;
    Image goRight;
    Image Static;
    BindingList<Action> actions;
    BindingList<Parametr> parametrs;
    BindingList<Factor> factors;
    BindingList<Idea> ideas;
    PictureBox AIView = new PictureBox();

    public AI(  int x,
                int y,
                Panel map,
                Image actionDown,
                Image actionUp,
                Image actionLeft,
                Image actionRight,
                Image goUp,
                Image goDown,
                Image goLeft,
                Image goRight,
                Image Static,
                BindingList<Action> actions,
                BindingList<Parametr> parametrs,
                BindingList<Factor> factors,
                BindingList<Idea> ideas)
    {
        this.x = x;
        this.y = y;
        this.map = map;
        this.actionDown = actionDown;
        this.actionUp = actionUp;
        this.actionLeft = actionLeft;
        this.actionRight = actionRight;
        this.goUp = goUp;
        this.goDown = goDown;
        this.goLeft = goLeft;
        this.goRight = goRight;
        this.Static = Static;
        this.actions = actions;
        this.parametrs = parametrs;
        this.factors = factors;
        this.ideas = ideas;
}

    public void show()
    {
        AIView.SizeMode = PictureBoxSizeMode.Zoom;
        AIView.Size = new Size(45, 45);
        AIView.Location = new Point(x*45, y*45);
        AIView.Image = Static;
        /*foreach (Control picture in map.Controls)
        {
            if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                var pic = picture as PictureBox;
                pic.Hide();
            }
        }*/
        map.Controls.Add(AIView);
        AIView.BringToFront();
        AIView.Show();
    }

    public bool isFactorPerformed(Factor factor)
    {
        switch (factor.type)
        {
            case "watching":
                return true;
              
            case "compare":
                return true;
                
            case "actionAvailable":
                return true;

            default:
                return false;
        }
    }

    public int powerOfIdea(Idea idea)
    {
        int result = 0;
        foreach (var factor in idea.weights)
        {
            result += (isFactorPerformed(factor.Item1) ? 1 : 0) * factor.Item2;
        }
        return result;
    }

    public void action(Action act)
    {
        int dx = 0;
        int dy = 0;
        if (act.xDistanceObject != 0)
        {
            x += act.xDistanceObject;
            if (act.xDistanceObject > 0)
            {
                AIView.Image = goRight;
                dx = 5;
            }
            else
            {
                AIView.Image = goLeft;
                dx = -5;
            }
        }
        if (act.yDistanceObject != 0)
        {
            y += act.yDistanceObject;
            if (act.yDistanceObject > 0)
            {
                AIView.Image = goUp;
                dy = -5;
            }
            else
            {
                AIView.Image = goDown;
                dy = 5;
            }
        }
        if ((dx != 0) || (dy != 0))
        {
            switch (dx, dy)
            {
                case (-1, 0): AIView.Image = goLeft; break;
                case (0, -1): AIView.Image = goDown; break;
                case (1, 0): AIView.Image = goRight; break;
                case (0, 1): AIView.Image = goUp; break;
            }
            Timer timer = new Timer();
            timer.Interval = 30; // каждые 30 миллисекунд
            int count = 0;
            int max = 9;
            timer.Tick += new EventHandler((o, ev) =>
            {
                AIView.Location = new Point(AIView.Location.X + dx, AIView.Location.Y + dy);
                count++;
                if (count == max)
                {
                    Timer t = o as Timer; // можно тут просто воспользоваться timer
                t.Stop();
                }
            });
            timer.Start();
        }
        AIView.Image = Static;
        foreach (var change in act.changesOfParametrs)
        {
            change.Item1.value += change.Item2;
            /*foreach (var parametr in parametrs)
            {
                //if (parametr.name == change.Item1) parametr.value += change.Item2;
            }*/
        }

        if (act.actionImage != "")
        {
            
            foreach (Control picture in map.Controls)
            {
                if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    var pic = picture as PictureBox;
                    if ((pic.Location.X == (x + 1) * 45) && (pic.Location.Y == y * 45) && (pic.ImageLocation == act.actionImage))
                    {
                        pic.ImageLocation = act.changesImage; AIView.Image = actionRight;
                    }
                    if ((pic.Location.X == x * 45) && (pic.Location.Y == (y + 1) * 45) && (pic.ImageLocation == act.actionImage))
                    {
                        pic.ImageLocation = act.changesImage; AIView.Image = actionDown;
                    }
                    if ((pic.Location.X == (x - 1) * 45) && (pic.Location.Y == y * 45) && (pic.ImageLocation == act.actionImage))
                    {
                        pic.ImageLocation = act.changesImage; AIView.Image = actionLeft;
                    }
                    if ((pic.Location.X == x * 45) && (pic.Location.Y == (y - 1) * 45) && (pic.ImageLocation == act.actionImage))
                    {
                        pic.ImageLocation = act.changesImage; AIView.Image = actionUp;
                    }
                }
            }
            Timer timer = new Timer();
            timer.Interval = 30; // каждые 30 миллисекунд
            int count = 0;
            int max = 9;
            timer.Tick += new EventHandler((o, ev) =>
            {
                count++;
                if (count == max)
                {
                    Timer t = o as Timer; // можно тут просто воспользоваться timer
                    t.Stop();
                }
            });
            timer.Start();
        }
        AIView.Image = Static;

    }

    public void smartLife()
    {
        while(true)
        {
            int temp;
            int max = -9999;
            Idea plan = null;
            foreach (var idea in ideas)
            {
                if ((temp = powerOfIdea(idea)) > max)
                {
                    plan = idea;
                    max = temp;
                }
            }
            if (plan != null)
                action(plan.action);
        }
    }
}