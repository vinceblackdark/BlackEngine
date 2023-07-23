using static System.Console;
using static MayaEngine.Render;
using System.Drawing;
namespace MayaEngine
{
    public interface IMayaUI
    {
        public void RunSelection();
        public int ReturnSelect();
        public void DrawOptions(string choiceText);
    }
    public class SwitchSelect : IMayaUI
    {
        private ConsoleKeyInfo keyInfo;
        private bool isSelected = false;
        private bool onlyDraw = false;
        private int selectedOption = 0;
        private int selectedElement = 0;
        private List<string> options;
        private List<string> selectedOptions;
        private string _choiceText = "";
        private Color selectedColor { get; set; }
        private Color unselectedColor { get; set; }

        private char selectedChar { get; set; }
        private char unselectedChar { get; set; }
        private int X { get; set; }
        private int Y { get; set; }

        private SettingsManager settingsManager = new SettingsManager();
        public MayaSound optionSwitch { get; set; } = new MayaSound("perc0", false);
        public MayaSound optionSelect { get; set; } = new MayaSound("perc1", false);

        public SwitchSelect(List<string> optionsList, int posX, int posY, Color selected, Color unselected, char selectedChar, char unselectedChar)
        {
            this.X = posX;
            this.Y = posY;
            this.selectedColor = selected;
            this.unselectedColor = unselected;
            this.selectedChar = selectedChar;
            this.unselectedChar = unselectedChar;

            this.options = new List<string>();
            this.selectedOptions = new List<string>();

            foreach (string option in optionsList)
            {
                options.Add($" {this.unselectedChar} " + option);
                selectedOptions.Add($" {this.selectedChar} " + option.ToUpper());
            }
        }

        private void GetInput()
        {
            while (!isSelected)
            {
                keyInfo = ReadKey(true);

                PlaySound();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (selectedOption == 0)
                            selectedOption = options.Count - 1;
                        else
                            selectedOption--;
                        UpdateOptions();
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (selectedOption == options.Count - 1)
                            selectedOption = 0;
                        else
                            selectedOption++;
                        UpdateOptions();
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if(selectedElement == 2) { selectedElement = 0; } else { selectedElement++; } 
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (selectedElement == 0) { selectedElement = 2 ; } else { selectedElement--; }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        isSelected = true;
                        break;
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Delete:
                    case ConsoleKey.Escape:
                        selectedOption = options.Count - 1;
                        isSelected = true;
                        break;
                }
            }
            ReturnSelect(); ReturnElement();
        }

        public int ReturnSelect()
        {
            return selectedOption;
        }

        public int ReturnElement()
        {
            return selectedElement;
        }

        public void DrawOptions(string choiceText)
        {
            _choiceText = choiceText;
            WriteString(X, Y - 2, choiceText);
            onlyDraw = true;
            UpdateOptions();
        }

        private void UpdateOptions()
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedOption)
                {
                    WriteStringPastel(X, Y + i, selectedOptions[i], selectedColor);
                }
                else
                {
                    WriteStringPastel(X, Y + i, options[i], unselectedColor);
                }
            }
            if(!onlyDraw)
            {
                if (settingsManager.isAnimation)
                {
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (i == selectedOption)
                        {
                            while (!KeyAvailable)
                            {
                                WriteStringPastel(X, Y + i, selectedOptions[i], selectedColor);
                                Thread.Sleep(125);
                                if (KeyAvailable) { break; }
                                WriteStringPastel(X, Y + i, options[i].ToUpper(), unselectedColor);
                                Thread.Sleep(125);
                                if (KeyAvailable) { break; }
                            }
                        }
                        else
                        {
                            WriteStringPastel(X, Y + i, options[i], unselectedColor);
                        }
                    }
                }
            }
           
        }

        private void PlaySound()
        {
            if (MainUI.settingsManager.isUISound)
            {
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    optionSelect.Play();
                }
                if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    optionSwitch.Play();
                }
                if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.D)
                {
                    optionSwitch.Play();
                }
            }
        }

        public void RunSelection()
        {
            WriteString(X, Y - 2, _choiceText);
            isSelected = false;
            onlyDraw = false;
            UpdateOptions();
            GetInput();
        }
    }
}
