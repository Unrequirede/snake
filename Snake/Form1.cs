using System;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        public Snake()
        {
            InitializeComponent();
        }


        //creates random object
        private Random random = new Random();
        //creates matrix that serves as the game
        int[,] playGround = new int[21, 16];
        bool foodExists = false;
        int length = 3;

        //starts game
        private void Snake_Load(object sender, EventArgs e)
        {
            int startX = random.Next(4, 14);
            int startY = random.Next(4, 9);
            playGround[startX, startY] = length;
        }

        //every couple milliseconds, iterate
        private void gameTick_Tick(object sender, EventArgs e)
        {
            Update();
            if (!foodExists)
                SpawnFood();
            Move();
            scoreLabel.Text = "Score: " + (length - 3).ToString();
        }

        //determines location of where snake will move based on user controls
        private new void Move()
        {
            int gameSpeed = 200 - (20 * (length - 3));
            int positionX = -1000;
            int positionY = -1000;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (playGround[i, j] == length)
                    {
                        positionX = i;
                        positionY = j;
                    }
                    if (playGround[i, j] > 0)
                        playGround[i, j]--;
                }
            }
            if (moveUp.Checked == true)
            {
                try
                {
                    if (playGround[positionX, positionY - 1] == -1)
                    {
                        length++;
                        foodExists = false;
                        gameTick.Interval = gameTick.Interval - gameSpeed;
                    }
                    if (playGround[positionX, positionY - 1] > 0)
                    {
                        GameOver();
                    }
                    playGround[positionX, positionY - 1] = length;
                }
                catch(IndexOutOfRangeException e)
                {
                    GameOver();
                }
            }
            else if (moveLeft.Checked == true)
            {
                try
                {
                    if (playGround[positionX - 1, positionY] == -1)
                    {
                        length++;
                        foodExists = false;
                        gameTick.Interval = gameTick.Interval - gameSpeed;
                    }
                    if (playGround[positionX - 1, positionY] > 0)
                    {
                        GameOver();
                    }
                    playGround[positionX - 1, positionY] = length;
                }
                catch (IndexOutOfRangeException e)
                {
                    GameOver();
                }
            }
            else if (moveRight.Checked == true)
            {
                try
                {
                    if (playGround[positionX + 1, positionY] == -1)
                    {
                        length++;
                        foodExists = false;
                        gameTick.Interval = gameTick.Interval - gameSpeed;
                    }
                    if (playGround[positionX + 1, positionY] > 0)
                    {
                        GameOver();
                    }
                    playGround[positionX + 1, positionY] = length;
                }
                catch (IndexOutOfRangeException e)
                {
                    GameOver();
                }
            }
            else if (moveDown.Checked == true)
            {
                try
                {
                    if (playGround[positionX, positionY + 1] == -1)
                    {
                        length++;
                        foodExists = false;
                        gameTick.Interval = gameTick.Interval - gameSpeed;
                    }
                    if (playGround[positionX, positionY + 1] > 0)
                    {
                        GameOver();
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    GameOver();
                }
                playGround[positionX, positionY + 1] = length;
            }
            else
            { }
        }

        private void SpawnFood()
        {
            while (!foodExists)
            {
                int foodX = random.Next(0, 20);
                int foodY = random.Next(0, 15);
                if (playGround[foodX, foodY] == 2)
                {
                    //food can't appear on worm
                }
                else if (playGround[foodX, foodY] == -1)
                {
                    //there cannot be more than one food on the board
                }
                else
                {
                    playGround[foodX, foodY] = -1;
                    foodExists = true;
                }
            }
        }

        private void GameOver()
        {
            gameTick.Enabled = false;
            MessageBox.Show("Congratulations! You lost! Your score was " + (length - 3).ToString() + ".");
        }

        private void moveUp_CheckedChanged(object sender, EventArgs e)
        {
            moveUp.Enabled = false;
            moveLeft.Enabled = true;
            moveDown.Enabled = false;
            moveRight.Enabled = true;
            moveLeft.Checked = false;
            moveDown.Checked = false;
            moveRight.Checked = false;
        }
        private void moveLeft_CheckedChanged(object sender, EventArgs e)
        {
            moveLeft.Enabled = false;
            moveUp.Enabled = true;
            moveDown.Enabled = true;
            moveRight.Enabled = false;
            moveUp.Checked = false;
            moveDown.Checked = false;
            moveRight.Checked = false;
        }

        private void moveDown_CheckedChanged(object sender, EventArgs e)
        {
            moveDown.Enabled = false;
            moveLeft.Enabled = true;
            moveUp.Enabled = false;
            moveRight.Enabled = true;
            moveUp.Checked = false;
            moveLeft.Checked = false;
            moveRight.Checked = false;
        }

        private void moveRight_CheckedChanged(object sender, EventArgs e)
        {
            moveRight.Enabled = false;
            moveLeft.Enabled = false;
            moveDown.Enabled = true;
            moveUp.Enabled = true;
            moveUp.Checked = false;
            moveLeft.Checked = false;
            moveDown.Checked = false;
        }

        private void Update()
        {
            if (playGround[0, 0] != 0)
                space1x1.Checked = true;
            else
                space1x1.Checked = false;
            if (playGround[1, 0] != 0)
                space2x1.Checked = true;
            else
                space2x1.Checked = false;
            if (playGround[2, 0] != 0)
                space3x1.Checked = true;
            else
                space3x1.Checked = false;
            if (playGround[3, 0] != 0)
                space4x1.Checked = true;
            else
                space4x1.Checked = false;
            if (playGround[4, 0] != 0)
                space5x1.Checked = true;
            else
                space5x1.Checked = false;
            if (playGround[5, 0] != 0)
                space6x1.Checked = true;
            else
                space6x1.Checked = false;
            if (playGround[6, 0] != 0)
                space7x1.Checked = true;
            else
                space7x1.Checked = false;
            if (playGround[7, 0] != 0)
                space8x1.Checked = true;
            else
                space8x1.Checked = false;
            if (playGround[8, 0] != 0)
                space9x1.Checked = true;
            else
                space9x1.Checked = false;
            if (playGround[9, 0] != 0)
                space10x1.Checked = true;
            else
                space10x1.Checked = false;
            if (playGround[10, 0] != 0)
                space11x1.Checked = true;
            else
                space11x1.Checked = false;
            if (playGround[11, 0] != 0)
                space12x1.Checked = true;
            else
                space12x1.Checked = false;
            if (playGround[12, 0] != 0)
                space13x1.Checked = true;
            else
                space13x1.Checked = false;
            if (playGround[13, 0] != 0)
                space14x1.Checked = true;
            else
                space14x1.Checked = false;
            if (playGround[14, 0] != 0)
                space15x1.Checked = true;
            else
                space15x1.Checked = false;
            if (playGround[15, 0] != 0)
                space16x1.Checked = true;
            else
                space16x1.Checked = false;
            if (playGround[16, 0] != 0)
                space17x1.Checked = true;
            else
                space17x1.Checked = false;
            if (playGround[17, 0] != 0)
                space18x1.Checked = true;
            else
                space18x1.Checked = false;
            if (playGround[18, 0] != 0)
                space19x1.Checked = true;
            else
                space19x1.Checked = false;
            if (playGround[19, 0] != 0)
                space20x1.Checked = true;
            else
                space20x1.Checked = false;
            if (playGround[0, 1] != 0)
                space1x2.Checked = true;
            else
                space1x2.Checked = false;
            if (playGround[1, 1] != 0)
                space2x2.Checked = true;
            else
                space2x2.Checked = false;
            if (playGround[2, 1] != 0)
                space3x2.Checked = true;
            else
                space3x2.Checked = false;
            if (playGround[3, 1] != 0)
                space4x2.Checked = true;
            else
                space4x2.Checked = false;
            if (playGround[4, 1] != 0)
                space5x2.Checked = true;
            else
                space5x2.Checked = false;
            if (playGround[5, 1] != 0)
                space6x2.Checked = true;
            else
                space6x2.Checked = false;
            if (playGround[6, 1] != 0)
                space7x2.Checked = true;
            else
                space7x2.Checked = false;
            if (playGround[7, 1] != 0)
                space8x2.Checked = true;
            else
                space8x2.Checked = false;
            if (playGround[8, 1] != 0)
                space9x2.Checked = true;
            else
                space9x2.Checked = false;
            if (playGround[9, 1] != 0)
                space10x2.Checked = true;
            else
                space10x2.Checked = false;
            if (playGround[10, 1] != 0)
                space11x2.Checked = true;
            else
                space11x2.Checked = false;
            if (playGround[11, 1] != 0)
                space12x2.Checked = true;
            else
                space12x2.Checked = false;
            if (playGround[12, 1] != 0)
                space13x2.Checked = true;
            else
                space13x2.Checked = false;
            if (playGround[13, 1] != 0)
                space14x2.Checked = true;
            else
                space14x2.Checked = false;
            if (playGround[14, 1] != 0)
                space15x2.Checked = true;
            else
                space15x2.Checked = false;
            if (playGround[15, 1] != 0)
                space16x2.Checked = true;
            else
                space16x2.Checked = false;
            if (playGround[16, 1] != 0)
                space17x2.Checked = true;
            else
                space17x2.Checked = false;
            if (playGround[17, 1] != 0)
                space18x2.Checked = true;
            else
                space18x2.Checked = false;
            if (playGround[18, 1] != 0)
                space19x2.Checked = true;
            else
                space19x2.Checked = false;
            if (playGround[19, 1] != 0)
                space20x2.Checked = true;
            else
                space20x2.Checked = false;
            if (playGround[0, 2] != 0)
                space1x3.Checked = true;
            else
                space1x3.Checked = false;
            if (playGround[1, 2] != 0)
                space2x3.Checked = true;
            else
                space2x3.Checked = false;
            if (playGround[2, 2] != 0)
                space3x3.Checked = true;
            else
                space3x3.Checked = false;
            if (playGround[3, 2] != 0)
                space4x3.Checked = true;
            else
                space4x3.Checked = false;
            if (playGround[4, 2] != 0)
                space5x3.Checked = true;
            else
                space5x3.Checked = false;
            if (playGround[5, 2] != 0)
                space6x3.Checked = true;
            else
                space6x3.Checked = false;
            if (playGround[6, 2] != 0)
                space7x3.Checked = true;
            else
                space7x3.Checked = false;
            if (playGround[7, 2] != 0)
                space8x3.Checked = true;
            else
                space8x3.Checked = false;
            if (playGround[8, 2] != 0)
                space9x3.Checked = true;
            else
                space9x3.Checked = false;
            if (playGround[9, 2] != 0)
                space10x3.Checked = true;
            else
                space10x3.Checked = false;
            if (playGround[10, 2] != 0)
                space11x3.Checked = true;
            else
                space11x3.Checked = false;
            if (playGround[11, 2] != 0)
                space12x3.Checked = true;
            else
                space12x3.Checked = false;
            if (playGround[12, 2] != 0)
                space13x3.Checked = true;
            else
                space13x3.Checked = false;
            if (playGround[13, 2] != 0)
                space14x3.Checked = true;
            else
                space14x3.Checked = false;
            if (playGround[14, 2] != 0)
                space15x3.Checked = true;
            else
                space15x3.Checked = false;
            if (playGround[15, 2] != 0)
                space16x3.Checked = true;
            else
                space16x3.Checked = false;
            if (playGround[16, 2] != 0)
                space17x3.Checked = true;
            else
                space17x3.Checked = false;
            if (playGround[17, 2] != 0)
                space18x3.Checked = true;
            else
                space18x3.Checked = false;
            if (playGround[18, 2] != 0)
                space19x3.Checked = true;
            else
                space19x3.Checked = false;
            if (playGround[19, 2] != 0)
                space20x3.Checked = true;
            else
                space20x3.Checked = false;
            if (playGround[0, 3] != 0)
                space1x4.Checked = true;
            else
                space1x4.Checked = false;
            if (playGround[1, 3] != 0)
                space2x4.Checked = true;
            else
                space2x4.Checked = false;
            if (playGround[2, 3] != 0)
                space3x4.Checked = true;
            else
                space3x4.Checked = false;
            if (playGround[3, 3] != 0)
                space4x4.Checked = true;
            else
                space4x4.Checked = false;
            if (playGround[4, 3] != 0)
                space5x4.Checked = true;
            else
                space5x4.Checked = false;
            if (playGround[5, 3] != 0)
                space6x4.Checked = true;
            else
                space6x4.Checked = false;
            if (playGround[6, 3] != 0)
                space7x4.Checked = true;
            else
                space7x4.Checked = false;
            if (playGround[7, 3] != 0)
                space8x4.Checked = true;
            else
                space8x4.Checked = false;
            if (playGround[8, 3] != 0)
                space9x4.Checked = true;
            else
                space9x4.Checked = false;
            if (playGround[9, 3] != 0)
                space10x4.Checked = true;
            else
                space10x4.Checked = false;
            if (playGround[10, 3] != 0)
                space11x4.Checked = true;
            else
                space11x4.Checked = false;
            if (playGround[11, 3] != 0)
                space12x4.Checked = true;
            else
                space12x4.Checked = false;
            if (playGround[12, 3] != 0)
                space13x4.Checked = true;
            else
                space13x4.Checked = false;
            if (playGround[13, 3] != 0)
                space14x4.Checked = true;
            else
                space14x4.Checked = false;
            if (playGround[14, 3] != 0)
                space15x4.Checked = true;
            else
                space15x4.Checked = false;
            if (playGround[15, 3] != 0)
                space16x4.Checked = true;
            else
                space16x4.Checked = false;
            if (playGround[16, 3] != 0)
                space17x4.Checked = true;
            else
                space17x4.Checked = false;
            if (playGround[17, 3] != 0)
                space18x4.Checked = true;
            else
                space18x4.Checked = false;
            if (playGround[18, 3] != 0)
                space19x4.Checked = true;
            else
                space19x4.Checked = false;
            if (playGround[19, 3] != 0)
                space20x4.Checked = true;
            else
                space20x4.Checked = false;
            if (playGround[0, 4] != 0)
                space1x5.Checked = true;
            else
                space1x5.Checked = false;
            if (playGround[1, 4] != 0)
                space2x5.Checked = true;
            else
                space2x5.Checked = false;
            if (playGround[2, 4] != 0)
                space3x5.Checked = true;
            else
                space3x5.Checked = false;
            if (playGround[3, 4] != 0)
                space4x5.Checked = true;
            else
                space4x5.Checked = false;
            if (playGround[4, 4] != 0)
                space5x5.Checked = true;
            else
                space5x5.Checked = false;
            if (playGround[5, 4] != 0)
                space6x5.Checked = true;
            else
                space6x5.Checked = false;
            if (playGround[6, 4] != 0)
                space7x5.Checked = true;
            else
                space7x5.Checked = false;
            if (playGround[7, 4] != 0)
                space8x5.Checked = true;
            else
                space8x5.Checked = false;
            if (playGround[8, 4] != 0)
                space9x5.Checked = true;
            else
                space9x5.Checked = false;
            if (playGround[9, 4] != 0)
                space10x5.Checked = true;
            else
                space10x5.Checked = false;
            if (playGround[10, 4] != 0)
                space11x5.Checked = true;
            else
                space11x5.Checked = false;
            if (playGround[11, 4] != 0)
                space12x5.Checked = true;
            else
                space12x5.Checked = false;
            if (playGround[12, 4] != 0)
                space13x5.Checked = true;
            else
                space13x5.Checked = false;
            if (playGround[13, 4] != 0)
                space14x5.Checked = true;
            else
                space14x5.Checked = false;
            if (playGround[14, 4] != 0)
                space15x5.Checked = true;
            else
                space15x5.Checked = false;
            if (playGround[15, 4] != 0)
                space16x5.Checked = true;
            else
                space16x5.Checked = false;
            if (playGround[16, 4] != 0)
                space17x5.Checked = true;
            else
                space17x5.Checked = false;
            if (playGround[17, 4] != 0)
                space18x5.Checked = true;
            else
                space18x5.Checked = false;
            if (playGround[18, 4] != 0)
                space19x5.Checked = true;
            else
                space19x5.Checked = false;
            if (playGround[19, 4] != 0)
                space20x5.Checked = true;
            else
                space20x5.Checked = false;
            if (playGround[0, 5] != 0)
                space1x6.Checked = true;
            else
                space1x6.Checked = false;
            if (playGround[1, 5] != 0)
                space2x6.Checked = true;
            else
                space2x6.Checked = false;
            if (playGround[2, 5] != 0)
                space3x6.Checked = true;
            else
                space3x6.Checked = false;
            if (playGround[3, 5] != 0)
                space4x6.Checked = true;
            else
                space4x6.Checked = false;
            if (playGround[4, 5] != 0)
                space5x6.Checked = true;
            else
                space5x6.Checked = false;
            if (playGround[5, 5] != 0)
                space6x6.Checked = true;
            else
                space6x6.Checked = false;
            if (playGround[6, 5] != 0)
                space7x6.Checked = true;
            else
                space7x6.Checked = false;
            if (playGround[7, 5] != 0)
                space8x6.Checked = true;
            else
                space8x6.Checked = false;
            if (playGround[8, 5] != 0)
                space9x6.Checked = true;
            else
                space9x6.Checked = false;
            if (playGround[9, 5] != 0)
                space10x6.Checked = true;
            else
                space10x6.Checked = false;
            if (playGround[10, 5] != 0)
                space11x6.Checked = true;
            else
                space11x6.Checked = false;
            if (playGround[11, 5] != 0)
                space12x6.Checked = true;
            else
                space12x6.Checked = false;
            if (playGround[12, 5] != 0)
                space13x6.Checked = true;
            else
                space13x6.Checked = false;
            if (playGround[13, 5] != 0)
                space14x6.Checked = true;
            else
                space14x6.Checked = false;
            if (playGround[14, 5] != 0)
                space15x6.Checked = true;
            else
                space15x6.Checked = false;
            if (playGround[15, 5] != 0)
                space16x6.Checked = true;
            else
                space16x6.Checked = false;
            if (playGround[16, 5] != 0)
                space17x6.Checked = true;
            else
                space17x6.Checked = false;
            if (playGround[17, 5] != 0)
                space18x6.Checked = true;
            else
                space18x6.Checked = false;
            if (playGround[18, 5] != 0)
                space19x6.Checked = true;
            else
                space19x6.Checked = false;
            if (playGround[19, 5] != 0)
                space20x6.Checked = true;
            else
                space20x6.Checked = false;
            if (playGround[0, 6] != 0)
                space1x7.Checked = true;
            else
                space1x7.Checked = false;
            if (playGround[1, 6] != 0)
                space2x7.Checked = true;
            else
                space2x7.Checked = false;
            if (playGround[2, 6] != 0)
                space3x7.Checked = true;
            else
                space3x7.Checked = false;
            if (playGround[3, 6] != 0)
                space4x7.Checked = true;
            else
                space4x7.Checked = false;
            if (playGround[4, 6] != 0)
                space5x7.Checked = true;
            else
                space5x7.Checked = false;
            if (playGround[5, 6] != 0)
                space6x7.Checked = true;
            else
                space6x7.Checked = false;
            if (playGround[6, 6] != 0)
                space7x7.Checked = true;
            else
                space7x7.Checked = false;
            if (playGround[7, 6] != 0)
                space8x7.Checked = true;
            else
                space8x7.Checked = false;
            if (playGround[8, 6] != 0)
                space9x7.Checked = true;
            else
                space9x7.Checked = false;
            if (playGround[9, 6] != 0)
                space10x7.Checked = true;
            else
                space10x7.Checked = false;
            if (playGround[10, 6] != 0)
                space11x7.Checked = true;
            else
                space11x7.Checked = false;
            if (playGround[11, 6] != 0)
                space12x7.Checked = true;
            else
                space12x7.Checked = false;
            if (playGround[12, 6] != 0)
                space13x7.Checked = true;
            else
                space13x7.Checked = false;
            if (playGround[13, 6] != 0)
                space14x7.Checked = true;
            else
                space14x7.Checked = false;
            if (playGround[14, 6] != 0)
                space15x7.Checked = true;
            else
                space15x7.Checked = false;
            if (playGround[15, 6] != 0)
                space16x7.Checked = true;
            else
                space16x7.Checked = false;
            if (playGround[16, 6] != 0)
                space17x7.Checked = true;
            else
                space17x7.Checked = false;
            if (playGround[17, 6] != 0)
                space18x7.Checked = true;
            else
                space18x7.Checked = false;
            if (playGround[18, 6] != 0)
                space19x7.Checked = true;
            else
                space19x7.Checked = false;
            if (playGround[19, 6] != 0)
                space20x7.Checked = true;
            else
                space20x7.Checked = false;
            if (playGround[0, 7] != 0)
                space1x8.Checked = true;
            else
                space1x8.Checked = false;
            if (playGround[1, 7] != 0)
                space2x8.Checked = true;
            else
                space2x8.Checked = false;
            if (playGround[2, 7] != 0)
                space3x8.Checked = true;
            else
                space3x8.Checked = false;
            if (playGround[3, 7] != 0)
                space4x8.Checked = true;
            else
                space4x8.Checked = false;
            if (playGround[4, 7] != 0)
                space5x8.Checked = true;
            else
                space5x8.Checked = false;
            if (playGround[5, 7] != 0)
                space6x8.Checked = true;
            else
                space6x8.Checked = false;
            if (playGround[6, 7] != 0)
                space7x8.Checked = true;
            else
                space7x8.Checked = false;
            if (playGround[7, 7] != 0)
                space8x8.Checked = true;
            else
                space8x8.Checked = false;
            if (playGround[8, 7] != 0)
                space9x8.Checked = true;
            else
                space9x8.Checked = false;
            if (playGround[9, 7] != 0)
                space10x8.Checked = true;
            else
                space10x8.Checked = false;
            if (playGround[10, 7] != 0)
                space11x8.Checked = true;
            else
                space11x8.Checked = false;
            if (playGround[11, 7] != 0)
                space12x8.Checked = true;
            else
                space12x8.Checked = false;
            if (playGround[12, 7] != 0)
                space13x8.Checked = true;
            else
                space13x8.Checked = false;
            if (playGround[13, 7] != 0)
                space14x8.Checked = true;
            else
                space14x8.Checked = false;
            if (playGround[14, 7] != 0)
                space15x8.Checked = true;
            else
                space15x8.Checked = false;
            if (playGround[15, 7] != 0)
                space16x8.Checked = true;
            else
                space16x8.Checked = false;
            if (playGround[16, 7] != 0)
                space17x8.Checked = true;
            else
                space17x8.Checked = false;
            if (playGround[17, 7] != 0)
                space18x8.Checked = true;
            else
                space18x8.Checked = false;
            if (playGround[18, 7] != 0)
                space19x8.Checked = true;
            else
                space19x8.Checked = false;
            if (playGround[19, 7] != 0)
                space20x8.Checked = true;
            else
                space20x8.Checked = false;
            if (playGround[0, 8] != 0)
                space1x9.Checked = true;
            else
                space1x9.Checked = false;
            if (playGround[1, 8] != 0)
                space2x9.Checked = true;
            else
                space2x9.Checked = false;
            if (playGround[2, 8] != 0)
                space3x9.Checked = true;
            else
                space3x9.Checked = false;
            if (playGround[3, 8] != 0)
                space4x9.Checked = true;
            else
                space4x9.Checked = false;
            if (playGround[4, 8] != 0)
                space5x9.Checked = true;
            else
                space5x9.Checked = false;
            if (playGround[5, 8] != 0)
                space6x9.Checked = true;
            else
                space6x9.Checked = false;
            if (playGround[6, 8] != 0)
                space7x9.Checked = true;
            else
                space7x9.Checked = false;
            if (playGround[7, 8] != 0)
                space8x9.Checked = true;
            else
                space8x9.Checked = false;
            if (playGround[8, 8] != 0)
                space9x9.Checked = true;
            else
                space9x9.Checked = false;
            if (playGround[9, 8] != 0)
                space10x9.Checked = true;
            else
                space10x9.Checked = false;
            if (playGround[10, 8] != 0)
                space11x9.Checked = true;
            else
                space11x9.Checked = false;
            if (playGround[11, 8] != 0)
                space12x9.Checked = true;
            else
                space12x9.Checked = false;
            if (playGround[12, 8] != 0)
                space13x9.Checked = true;
            else
                space13x9.Checked = false;
            if (playGround[13, 8] != 0)
                space14x9.Checked = true;
            else
                space14x9.Checked = false;
            if (playGround[14, 8] != 0)
                space15x9.Checked = true;
            else
                space15x9.Checked = false;
            if (playGround[15, 8] != 0)
                space16x9.Checked = true;
            else
                space16x9.Checked = false;
            if (playGround[16, 8] != 0)
                space17x9.Checked = true;
            else
                space17x9.Checked = false;
            if (playGround[17, 8] != 0)
                space18x9.Checked = true;
            else
                space18x9.Checked = false;
            if (playGround[18, 8] != 0)
                space19x9.Checked = true;
            else
                space19x9.Checked = false;
            if (playGround[19, 8] != 0)
                space20x9.Checked = true;
            else
                space20x9.Checked = false;
            if (playGround[0, 9] != 0)
                space1x10.Checked = true;
            else
                space1x10.Checked = false;
            if (playGround[1, 9] != 0)
                space2x10.Checked = true;
            else
                space2x10.Checked = false;
            if (playGround[2, 9] != 0)
                space3x10.Checked = true;
            else
                space3x10.Checked = false;
            if (playGround[3, 9] != 0)
                space4x10.Checked = true;
            else
                space4x10.Checked = false;
            if (playGround[4, 9] != 0)
                space5x10.Checked = true;
            else
                space5x10.Checked = false;
            if (playGround[5, 9] != 0)
                space6x10.Checked = true;
            else
                space6x10.Checked = false;
            if (playGround[6, 9] != 0)
                space7x10.Checked = true;
            else
                space7x10.Checked = false;
            if (playGround[7, 9] != 0)
                space8x10.Checked = true;
            else
                space8x10.Checked = false;
            if (playGround[8, 9] != 0)
                space9x10.Checked = true;
            else
                space9x10.Checked = false;
            if (playGround[9, 9] != 0)
                space10x10.Checked = true;
            else
                space10x10.Checked = false;
            if (playGround[10, 9] != 0)
                space11x10.Checked = true;
            else
                space11x10.Checked = false;
            if (playGround[11, 9] != 0)
                space12x10.Checked = true;
            else
                space12x10.Checked = false;
            if (playGround[12, 9] != 0)
                space13x10.Checked = true;
            else
                space13x10.Checked = false;
            if (playGround[13, 9] != 0)
                space14x10.Checked = true;
            else
                space14x10.Checked = false;
            if (playGround[14, 9] != 0)
                space15x10.Checked = true;
            else
                space15x10.Checked = false;
            if (playGround[15, 9] != 0)
                space16x10.Checked = true;
            else
                space16x10.Checked = false;
            if (playGround[16, 9] != 0)
                space17x10.Checked = true;
            else
                space17x10.Checked = false;
            if (playGround[17, 9] != 0)
                space18x10.Checked = true;
            else
                space18x10.Checked = false;
            if (playGround[18, 9] != 0)
                space19x10.Checked = true;
            else
                space19x10.Checked = false;
            if (playGround[19, 9] != 0)
                space20x10.Checked = true;
            else
                space20x10.Checked = false;
            if (playGround[0, 10] != 0)
                space1x11.Checked = true;
            else
                space1x11.Checked = false;
            if (playGround[1, 10] != 0)
                space2x11.Checked = true;
            else
                space2x11.Checked = false;
            if (playGround[2, 10] != 0)
                space3x11.Checked = true;
            else
                space3x11.Checked = false;
            if (playGround[3, 10] != 0)
                space4x11.Checked = true;
            else
                space4x11.Checked = false;
            if (playGround[4, 10] != 0)
                space5x11.Checked = true;
            else
                space5x11.Checked = false;
            if (playGround[5, 10] != 0)
                space6x11.Checked = true;
            else
                space6x11.Checked = false;
            if (playGround[6, 10] != 0)
                space7x11.Checked = true;
            else
                space7x11.Checked = false;
            if (playGround[7, 10] != 0)
                space8x11.Checked = true;
            else
                space8x11.Checked = false;
            if (playGround[8, 10] != 0)
                space9x11.Checked = true;
            else
                space9x11.Checked = false;
            if (playGround[9, 10] != 0)
                space10x11.Checked = true;
            else
                space10x11.Checked = false;
            if (playGround[10, 10] != 0)
                space11x11.Checked = true;
            else
                space11x11.Checked = false;
            if (playGround[11, 10] != 0)
                space12x11.Checked = true;
            else
                space12x11.Checked = false;
            if (playGround[12, 10] != 0)
                space13x11.Checked = true;
            else
                space13x11.Checked = false;
            if (playGround[13, 10] != 0)
                space14x11.Checked = true;
            else
                space14x11.Checked = false;
            if (playGround[14, 10] != 0)
                space15x11.Checked = true;
            else
                space15x11.Checked = false;
            if (playGround[15, 10] != 0)
                space16x11.Checked = true;
            else
                space16x11.Checked = false;
            if (playGround[16, 10] != 0)
                space17x11.Checked = true;
            else
                space17x11.Checked = false;
            if (playGround[17, 10] != 0)
                space18x11.Checked = true;
            else
                space18x11.Checked = false;
            if (playGround[18, 10] != 0)
                space19x11.Checked = true;
            else
                space19x11.Checked = false;
            if (playGround[19, 10] != 0)
                space20x11.Checked = true;
            else
                space20x11.Checked = false;
            if (playGround[0, 11] != 0)
                space1x12.Checked = true;
            else
                space1x12.Checked = false;
            if (playGround[1, 11] != 0)
                space2x12.Checked = true;
            else
                space2x12.Checked = false;
            if (playGround[2, 11] != 0)
                space3x12.Checked = true;
            else
                space3x12.Checked = false;
            if (playGround[3, 11] != 0)
                space4x12.Checked = true;
            else
                space4x12.Checked = false;
            if (playGround[4, 11] != 0)
                space5x12.Checked = true;
            else
                space5x12.Checked = false;
            if (playGround[5, 11] != 0)
                space6x12.Checked = true;
            else
                space6x12.Checked = false;
            if (playGround[6, 11] != 0)
                space7x12.Checked = true;
            else
                space7x12.Checked = false;
            if (playGround[7, 11] != 0)
                space8x12.Checked = true;
            else
                space8x12.Checked = false;
            if (playGround[8, 11] != 0)
                space9x12.Checked = true;
            else
                space9x12.Checked = false;
            if (playGround[9, 11] != 0)
                space10x12.Checked = true;
            else
                space10x12.Checked = false;
            if (playGround[10, 11] != 0)
                space11x12.Checked = true;
            else
                space11x12.Checked = false;
            if (playGround[11, 11] != 0)
                space12x12.Checked = true;
            else
                space12x12.Checked = false;
            if (playGround[12, 11] != 0)
                space13x12.Checked = true;
            else
                space13x12.Checked = false;
            if (playGround[13, 11] != 0)
                space14x12.Checked = true;
            else
                space14x12.Checked = false;
            if (playGround[14, 11] != 0)
                space15x12.Checked = true;
            else
                space15x12.Checked = false;
            if (playGround[15, 11] != 0)
                space16x12.Checked = true;
            else
                space16x12.Checked = false;
            if (playGround[16, 11] != 0)
                space17x12.Checked = true;
            else
                space17x12.Checked = false;
            if (playGround[17, 11] != 0)
                space18x12.Checked = true;
            else
                space18x12.Checked = false;
            if (playGround[18, 11] != 0)
                space19x12.Checked = true;
            else
                space19x12.Checked = false;
            if (playGround[19, 11] != 0)
                space20x12.Checked = true;
            else
                space20x12.Checked = false;
            if (playGround[0, 12] != 0)
                space1x13.Checked = true;
            else
                space1x13.Checked = false;
            if (playGround[1, 12] != 0)
                space2x13.Checked = true;
            else
                space2x13.Checked = false;
            if (playGround[2, 12] != 0)
                space3x13.Checked = true;
            else
                space3x13.Checked = false;
            if (playGround[3, 12] != 0)
                space4x13.Checked = true;
            else
                space4x13.Checked = false;
            if (playGround[4, 12] != 0)
                space5x13.Checked = true;
            else
                space5x13.Checked = false;
            if (playGround[5, 12] != 0)
                space6x13.Checked = true;
            else
                space6x13.Checked = false;
            if (playGround[6, 12] != 0)
                space7x13.Checked = true;
            else
                space7x13.Checked = false;
            if (playGround[7, 12] != 0)
                space8x13.Checked = true;
            else
                space8x13.Checked = false;
            if (playGround[8, 12] != 0)
                space9x13.Checked = true;
            else
                space9x13.Checked = false;
            if (playGround[9, 12] != 0)
                space10x13.Checked = true;
            else
                space10x13.Checked = false;
            if (playGround[10, 12] != 0)
                space11x13.Checked = true;
            else
                space11x13.Checked = false;
            if (playGround[11, 12] != 0)
                space12x13.Checked = true;
            else
                space12x13.Checked = false;
            if (playGround[12, 12] != 0)
                space13x13.Checked = true;
            else
                space13x13.Checked = false;
            if (playGround[13, 12] != 0)
                space14x13.Checked = true;
            else
                space14x13.Checked = false;
            if (playGround[14, 12] != 0)
                space15x13.Checked = true;
            else
                space15x13.Checked = false;
            if (playGround[15, 12] != 0)
                space16x13.Checked = true;
            else
                space16x13.Checked = false;
            if (playGround[16, 12] != 0)
                space17x13.Checked = true;
            else
                space17x13.Checked = false;
            if (playGround[17, 12] != 0)
                space18x13.Checked = true;
            else
                space18x13.Checked = false;
            if (playGround[18, 12] != 0)
                space19x13.Checked = true;
            else
                space19x13.Checked = false;
            if (playGround[19, 12] != 0)
                space20x13.Checked = true;
            else
                space20x13.Checked = false;
            if (playGround[0, 13] != 0)
                space1x14.Checked = true;
            else
                space1x14.Checked = false;
            if (playGround[1, 13] != 0)
                space2x14.Checked = true;
            else
                space2x14.Checked = false;
            if (playGround[2, 13] != 0)
                space3x14.Checked = true;
            else
                space3x14.Checked = false;
            if (playGround[3, 13] != 0)
                space4x14.Checked = true;
            else
                space4x14.Checked = false;
            if (playGround[4, 13] != 0)
                space5x14.Checked = true;
            else
                space5x14.Checked = false;
            if (playGround[5, 13] != 0)
                space6x14.Checked = true;
            else
                space6x14.Checked = false;
            if (playGround[6, 13] != 0)
                space7x14.Checked = true;
            else
                space7x14.Checked = false;
            if (playGround[7, 13] != 0)
                space8x14.Checked = true;
            else
                space8x14.Checked = false;
            if (playGround[8, 13] != 0)
                space9x14.Checked = true;
            else
                space9x14.Checked = false;
            if (playGround[9, 13] != 0)
                space10x14.Checked = true;
            else
                space10x14.Checked = false;
            if (playGround[10, 13] != 0)
                space11x14.Checked = true;
            else
                space11x14.Checked = false;
            if (playGround[11, 13] != 0)
                space12x14.Checked = true;
            else
                space12x14.Checked = false;
            if (playGround[12, 13] != 0)
                space13x14.Checked = true;
            else
                space13x14.Checked = false;
            if (playGround[13, 13] != 0)
                space14x14.Checked = true;
            else
                space14x14.Checked = false;
            if (playGround[14, 13] != 0)
                space15x14.Checked = true;
            else
                space15x14.Checked = false;
            if (playGround[15, 13] != 0)
                space16x14.Checked = true;
            else
                space16x14.Checked = false;
            if (playGround[16, 13] != 0)
                space17x14.Checked = true;
            else
                space17x14.Checked = false;
            if (playGround[17, 13] != 0)
                space18x14.Checked = true;
            else
                space18x14.Checked = false;
            if (playGround[18, 13] != 0)
                space19x14.Checked = true;
            else
                space19x14.Checked = false;
            if (playGround[19, 13] != 0)
                space20x14.Checked = true;
            else
                space20x14.Checked = false;
            if (playGround[0, 14] != 0)
                space1x15.Checked = true;
            else
                space1x15.Checked = false;
            if (playGround[1, 14] != 0)
                space2x15.Checked = true;
            else
                space2x15.Checked = false;
            if (playGround[2, 14] != 0)
                space3x15.Checked = true;
            else
                space3x15.Checked = false;
            if (playGround[3, 14] != 0)
                space4x15.Checked = true;
            else
                space4x15.Checked = false;
            if (playGround[4, 14] != 0)
                space5x15.Checked = true;
            else
                space5x15.Checked = false;
            if (playGround[5, 14] != 0)
                space6x15.Checked = true;
            else
                space6x15.Checked = false;
            if (playGround[6, 14] != 0)
                space7x15.Checked = true;
            else
                space7x15.Checked = false;
            if (playGround[7, 14] != 0)
                space8x15.Checked = true;
            else
                space8x15.Checked = false;
            if (playGround[8, 14] != 0)
                space9x15.Checked = true;
            else
                space9x15.Checked = false;
            if (playGround[9, 14] != 0)
                space10x15.Checked = true;
            else
                space10x15.Checked = false;
            if (playGround[10, 14] != 0)
                space11x15.Checked = true;
            else
                space11x15.Checked = false;
            if (playGround[11, 14] != 0)
                space12x15.Checked = true;
            else
                space12x15.Checked = false;
            if (playGround[12, 14] != 0)
                space13x15.Checked = true;
            else
                space13x15.Checked = false;
            if (playGround[13, 14] != 0)
                space14x15.Checked = true;
            else
                space14x15.Checked = false;
            if (playGround[14, 14] != 0)
                space15x15.Checked = true;
            else
                space15x15.Checked = false;
            if (playGround[15, 14] != 0)
                space16x15.Checked = true;
            else
                space16x15.Checked = false;
            if (playGround[16, 14] != 0)
                space17x15.Checked = true;
            else
                space17x15.Checked = false;
            if (playGround[17, 14] != 0)
                space18x15.Checked = true;
            else
                space18x15.Checked = false;
            if (playGround[18, 14] != 0)
                space19x15.Checked = true;
            else
                space19x15.Checked = false;
            if (playGround[19, 14] != 0)
                space20x15.Checked = true;
            else
                space20x15.Checked = false;
        }
    }
}
