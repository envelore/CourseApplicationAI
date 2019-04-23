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
        public CreateAI()
        {
            InitializeComponent();
            Action goDown = new Action("идти вниз", "", "", null, 0, -1); actions.Add(goDown);
            Action goUp = new Action("идти вверх", "", "", null, 0, 1); actions.Add(goUp);
            Action goRight = new Action("идти вправо", "", "", null, -1, 0); actions.Add(goRight);
            Action goLeft = new Action("идти вправо", "", "", null, 1, 0); actions.Add(goLeft);
            Action stop = new Action("остановиться", "", "", null, 0, 0); actions.Add(stop);
            Idea ideaGoDown = new Idea(goDown, null); ideas.Add(ideaGoDown);
            Idea ideaGoUp = new Idea(goUp, null); ideas.Add(ideaGoUp);
            Idea ideaGoRight = new Idea(goRight, null); ideas.Add(ideaGoRight);
            Idea ideaGoLeft = new Idea(goLeft, null); ideas.Add(ideaGoLeft);
            Idea ideaStop = new Idea(stop, null); ideas.Add(ideaStop);
            tableViewActions.DataSource = actions;
            tableViewFactors.DataSource = factors;
            tableViewActionsFactors.DataSource = ideas;
        }

        int currentPanel;
        List<Image> imagesAI;
        List<Action> actions = new List<Action>();
        List<Parametr> parametrs = new List<Parametr>();
        List<Factor> factors = new List<Factor>();
        List <Idea> ideas = new List<Idea>();

        private void ButtonAddFactor_Click(object sender, EventArgs e)
        {
            tableEditor view = new tableEditor();
            view.source = tableViewFactors;
            view.creator = this;
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
            tableViewParam.Rows.Add();
        }

        private void ButtonDeleteFactor_Click(object sender, EventArgs e)
        {
            if ((tableViewFactors.CurrentRow != null))
            {
                tableViewFactors.Rows.Remove(tableViewFactors.CurrentRow);
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

        private void TableViewActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            List<string> names = new List<string>();
            foreach (var act in actions)
            {
                names.Add(act.name);
            }
            tableViewActions.DataSource = names;
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
    }
}

class Parametr
{
    public string name;
    public int value;

    public Parametr(string n, int val)
    {
        name = n;
        value = val;
    }
}

class Factor
{
    public string name;
    public string type;
    public string nameOfComparedParametr;
    public string typeCompare; // >, < or =
    public int valueOfCompare;
    public string actionName;
    public string whatDoesImageAISee;
    public int distanceWatch;
    public string nameOfAction;

    public Factor(string type, object[] parametrs)
    {
        this.type = type;
        switch (type)
        {
            case "watching":
                whatDoesImageAISee = parametrs[0] as string;
                distanceWatch = (int)parametrs[1];
                break;
            case "compare":
                nameOfComparedParametr = parametrs[0] as string;
                typeCompare = parametrs[1] as string;
                valueOfCompare = (int)parametrs[2];
                break;
            case "actionAvailable":
                nameOfAction = parametrs[0] as string;
                break;
        }
    } 
}

class Action
{
    public string name { get; set; }
    public int xDistanceSubject;
    public int yDistanceSubject;
    public int xDistanceObject;
    public int yDistanceObject;
    public (string, int)[] changesOfParametrs;
    public string changesImage;
    public string actionImage;
    public Action(string name, string actionimg, string changesimg, (string, int)[] changes, int deltax, int deltay)
    {
        this.name = name;
        actionImage = actionimg;
        changesImage = changesimg;
        changesOfParametrs = changes;
        xDistanceObject = deltax;
        yDistanceObject = deltay;
    }
}

class Idea
{
    public Action action;
    public (Factor, int)[] weights;
    public string name { get; set; }

    public Idea(Action act, (Factor, int)[] weights)
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
    string pathToImages = "";
    Image actionDown;
    Image actionUp;
    Image actionLeft;
    Image actionRight;
    Image goUp;
    Image goDown;
    Image goLeft;
    Image goRight;
    Image Static;
    Action[] actions = { };
    Parametr[] parametrs = { };
    Factor[] factors = { };
    Idea[] ideas;
    PictureBox AIView;

    public AI(  int x,
                int y,
                Panel map,
                string pathToImages,
                Image actionDown,
                Image actionUp,
                Image actionLeft,
                Image actionRight,
                Image goUp,
                Image goDown,
                Image goLeft,
                Image goRight,
                Image Static,
                Action[] actions,
                Parametr[] parametrs,
                Factor[] factors,
                Idea[] ideas)
    {
        this.x = x;
        this.y = y;
        this.map = map;
        this.pathToImages = pathToImages;
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
        AIView.Location = new Point(x, y);
        AIView.Image = Static;
        map.Controls.Add(AIView);
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
            foreach (var parametr in parametrs)
            {
                if (parametr.name == change.Item1) parametr.value += change.Item2;
            }
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