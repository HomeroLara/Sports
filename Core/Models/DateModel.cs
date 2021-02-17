using System;
using Sports.Core;
using Sports.Core.Helpers;

public class DateModel : Observable
{
    public string Month { get; set; }
    public string Day { get; set; }
    public string DayWeek { get; set; }
    public bool Selected { get; set; }
    public DateTime Date { get; set; }

    private string _backgroundColor;
    private string _textColor;


    public string BackgroundColor
    {
        get => _backgroundColor;
        set
        {
            _backgroundColor = value;
            OnPropertyChanged("BackgroundColor");
        }
    }

    public string TextColor
    {
        get => _textColor;
        set
        {
            _textColor = value;
            OnPropertyChanged("TextColor");
        }
    }


    public DateModel()
    {
    }
}
