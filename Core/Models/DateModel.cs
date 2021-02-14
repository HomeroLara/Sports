using System;
using Sports.Core;

public class DateModel : Observable
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public string DayWeek { get; set; }
    public bool Selected { get; set; }

    private string _backgroundColor;
    public string BackgroundColor
    {
        get => _backgroundColor;
        set
        {
            _backgroundColor = value;
            OnPropertyChanged("BackgroundColor");
        }
    }

    private string _textColor;
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

    public DateTime GetDate()
    {
        return new DateTime(Year, Month, Day);
    }
}
