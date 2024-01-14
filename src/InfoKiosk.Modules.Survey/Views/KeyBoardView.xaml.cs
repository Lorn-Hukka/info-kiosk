using InfoKiosk.Modules.Survey.Models;
using InfoKiosk.Modules.Survey.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InfoKiosk.Modules.Survey.Views
{
    /// <summary>
    /// Logika interakcji dla klasy KeyBoardView.xaml
    /// </summary>
    public partial class KeyBoardView : UserControl
    {
        
        private bool capsLockEnabled = false;
        private bool shiftEnabled = false;
        Pytanie QuestionType;
        int countvalidation;
        int _currentQuestion;
        private ObservableCollection<ButtonModel> buttons;
        public delegate void SelectionChangedEventHandler(string type);
        public static event SelectionChangedEventHandler SelectionChanged;
        private SurveyDbContext _context;
        public KeyBoardView(KeyBoardViewModel viewModel,SurveyDbContext context)
        {
            DataContext = viewModel;
            _context = context;
            SurveyQuestionView.idSurveyProvider += HandleidSurveyProvider;
            SurveyQuestionView.CurrentQuestion += HandleCurrentQuestion;
            InitializeComponent();
            Grid_Closed_Like.Visibility = Visibility.Hidden;
            Grid_Closed_Stance.Visibility = Visibility.Hidden;
            Grid_Select_Survey.Visibility = Visibility.Visible;
            Grid_Open_Keyboard.Visibility = Visibility.Hidden;

            InitializeButtons();
            UpdateButtonsContent();
            Loaded += ScreenKeyBoard_Loaded;
        }
        private void ScreenKeyBoard_Loaded(object sender, RoutedEventArgs e)
        {
            // Ustaw kursor na pozycji 0 w TextBox
            textBox.Focus();
            textBox.CaretIndex = 0;
        }
        private void InitializeButtons()
        {
            buttons = new ObservableCollection<ButtonModel>
            {
                // Pierwszy rząd
            new ButtonModel("1"), new ButtonModel("2"), new ButtonModel("3"),
            new ButtonModel("4"), new ButtonModel("5"), new ButtonModel("6"),
            new ButtonModel("7"), new ButtonModel("8"), new ButtonModel("9"),
            new ButtonModel("0"), new ButtonModel("-"), new ButtonModel("⌫"),
                // Drugi rząd
            new ButtonModel("Q"), new ButtonModel("W"), new ButtonModel("E"),
            new ButtonModel("R"), new ButtonModel("T"), new ButtonModel("Y"),
            new ButtonModel("U"), new ButtonModel("I"), new ButtonModel("O"),
            new ButtonModel("P"),new ButtonModel("("),new ButtonModel(")"),
            // Trzeci rząd
            new ButtonModel("⇪"), new ButtonModel("A"), new ButtonModel("S"),
            new ButtonModel("D"), new ButtonModel("F"), new ButtonModel("G"),
            new ButtonModel("H"), new ButtonModel("J"), new ButtonModel("K"),
            new ButtonModel("L"), new ButtonModel(":"), new ButtonModel("\""),
           
            // Czwarty rząd
            new ButtonModel("Alt"),new ButtonModel("Z"), new ButtonModel("X"),
            new ButtonModel("C"), new ButtonModel("V"), new ButtonModel("B"),
            new ButtonModel("N"), new ButtonModel("M"), new ButtonModel(","),
            new ButtonModel("."),

        };

            // Dodaj przyciski do siatki
            KeyboardGrid.ItemsSource = buttons;
        }

        private void Button_Click_Keyboard(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            if (content == "⇪")
            {
                capsLockEnabled = !capsLockEnabled;
            }
            else if (content == "Alt")
            {
                shiftEnabled = !shiftEnabled;
            }
            else if (content == "⌫")
            {
                if (textBox.SelectionStart > 0)
                {
                    int cursorIndex = textBox.SelectionStart;
                    textBox.Text = textBox.Text.Remove(cursorIndex - 1, 1);
                    textBox.SelectionStart = cursorIndex - 1;
                }
            }
            else
            {
                // Dostosuj wielkość liter w zależności od stanu Caps Lock i Shift
                content = GetModifiedContent(content);

                int cursorIndex = textBox.CaretIndex; // Pobierz pozycję kursora
                textBox.Text = textBox.Text.Insert(cursorIndex, content); // Wstaw nowy tekst w miejsce kursora
                textBox.CaretIndex = cursorIndex + content.Length; // Ustaw kursor po wstawionym tekście
            }

            UpdateButtonsContent();
        }

        private string GetModifiedContent(string originalContent)
        {
            // Funkcja do modyfikacji zawartości w zależności od Caps Lock i Shift
            string modifiedContent = originalContent;

            if (capsLockEnabled && !shiftEnabled)
            {
                // Jeśli tylko Caps Lock jest włączony, użyj dużych liter
                modifiedContent = originalContent.ToUpper();
            }
            else if (!capsLockEnabled && shiftEnabled)
            {
                // Jeśli tylko Shift jest włączony, użyj polskich liter
                modifiedContent = GetPolishCharacter(originalContent.ToLower());
            }
            else if (capsLockEnabled && shiftEnabled)
            {
                // Jeśli zarówno Caps Lock, jak i Shift są włączone, użyj dużych polskich liter
                modifiedContent = GetPolishCharacter(originalContent);
            }
            else
            {
                // W przeciwnym razie, użyj małych liter
                modifiedContent = originalContent.ToLower();
            }

            return modifiedContent;
        }

        private string GetPolishCharacter(string originalContent)
        {
            // Funkcja do zamiany na polskie znaki
            switch (originalContent)
            {
                case "a": return "ą";
                case "c": return "ć";
                case "e": return "ę";
                case "l": return "ł";
                case "n": return "ń";
                case "o": return "ó";
                case "s": return "ś";
                case "z": return "ż";
                case "x": return "ź";
                case "A": return "Ą";
                case "C": return "Ć";
                case "E": return "Ę";
                case "L": return "Ł";
                case "N": return "Ń";
                case "O": return "Ó";
                case "S": return "Ś";
                case "Z": return "Ż";
                case "X": return "Ź";
                // Dodaj inne przypadki według potrzeb
                default: return originalContent;
            }
        }

        private void UpdateButtonsContent()
        {
            foreach (var buttonModel in buttons)
            {
                if (buttonModel.OriginalContent != "⇪" && buttonModel.OriginalContent != "Alt"
                    && buttonModel.OriginalContent != "&#x232B;")
                {
                    buttonModel.Content = GetModifiedContent(buttonModel.OriginalContent);
                }
                else
                {
                    buttonModel.Content = buttonModel.OriginalContent;
                }
            }
        }

        private void HandleidSurveyProvider(int idSurvey)
        {
            if (idSurvey == 0)
            {

                Grid_Select_Survey.Visibility = Visibility.Visible;
                Grid_Closed_Like.Visibility = Visibility.Hidden;
                Grid_Closed_Stance.Visibility = Visibility.Hidden;
                Grid_Open_Keyboard.Visibility = Visibility.Hidden;

            }
            else
            {
                QuestionType = (Pytanie)_context.Pytania.Where(x => x.IdPytania == idSurvey).FirstOrDefault();
                if (QuestionType.TypPytania == "OTWARTE   ")
                {
                    Grid_Select_Survey.Visibility = Visibility.Hidden;
                    Grid_Closed_Like.Visibility = Visibility.Hidden;
                    Grid_Closed_Stance.Visibility = Visibility.Hidden;
                    Grid_Open_Keyboard.Visibility = Visibility.Visible;
                }
                else if (QuestionType.TypPytania == "ODCZUCIE  ")
                {
                    Grid_Select_Survey.Visibility = Visibility.Hidden;
                    Grid_Closed_Like.Visibility = Visibility.Visible;
                    Grid_Closed_Stance.Visibility = Visibility.Hidden;
                    Grid_Open_Keyboard.Visibility = Visibility.Hidden;
                }
                else if (QuestionType.TypPytania == "STANOWISKO")
                {
                    Grid_Select_Survey.Visibility = Visibility.Hidden;
                    Grid_Closed_Like.Visibility = Visibility.Hidden;
                    Grid_Closed_Stance.Visibility = Visibility.Visible;
                    Grid_Open_Keyboard.Visibility = Visibility.Hidden;
                }
                else if (idSurvey == 0)
                {
                    Grid_Select_Survey.Visibility = Visibility.Visible;
                    Grid_Closed_Like.Visibility = Visibility.Hidden;
                    Grid_Closed_Stance.Visibility = Visibility.Hidden;
                    Grid_Open_Keyboard.Visibility = Visibility.Hidden;
                }
            }
        }
        private void HandleCurrentQuestion(int currentQuestion)
        {
            _currentQuestion = currentQuestion;
        }

        private void Button_Click_Answer(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != string.Empty)
            {

                countvalidation = _context.Pytania.Where(x => x.IdAnkiety == QuestionType.IdAnkiety).Count();
                int maxIdOdpowiedzi = _context.Odpowiedzi.Any() ? _context.Odpowiedzi.Max(x => x.IdOdpowiedzi) + 1 : 1;
                if (true) {
                    _context.Odpowiedzi.Add(new Odpowiedz()
                    {

                        IdOdpowiedzi = maxIdOdpowiedzi,
                        IdPytania = QuestionType.IdPytania,
                        TrescOdpowiedzi = textBox.Text,
                        CreationTime = DateTime.Now.Date
                        
                    });;
                    _context.SaveChanges();
                    textBox.Text = string.Empty;
                    if (countvalidation > _currentQuestion)
                    {
                        SelectionChanged?.Invoke("Next");
                    }
                    else SelectionChanged?.Invoke("Last");
                }
            }
        }

        private void Previous_survey_Click(object sender, RoutedEventArgs e)
        {
            SelectionChanged?.Invoke("Previous");
        }

        private void Select_survey_Click(object sender, RoutedEventArgs e)
        {
            SelectionChanged?.Invoke("Select");
        }

        private void Next_survey_Click(object sender, RoutedEventArgs e)
        {
            SelectionChanged?.Invoke("Next");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            int maxIdOdpowiedzi = _context.Odpowiedzi.Any() ? _context.Odpowiedzi.Max(x => x.IdOdpowiedzi) + 1 : 1;
            _context.Odpowiedzi.Add(new Odpowiedz()
            {

                IdOdpowiedzi = maxIdOdpowiedzi,
                IdPytania = QuestionType.IdPytania,
                TrescOdpowiedzi = content,
                CreationTime = DateTime.Now.Date

            }); ;
            _context.SaveChanges();
            if (countvalidation > _currentQuestion)
            {
                SelectionChanged?.Invoke("Next");
            }
            else SelectionChanged?.Invoke("Last");
            
        }
    }
}
