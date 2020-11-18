using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        private ObservableCollection<Brush> colorCollection;
        private ObservableCollection<string> meetingSubjectCollection;
        public event PropertyChangedEventHandler PropertyChanged;
        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();

        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("Board Meeting");
            meetingSubjectCollection.Add("Development Meeting");
            meetingSubjectCollection.Add("Project Plan Meeting");
            meetingSubjectCollection.Add("Support - Web Meeting");
            meetingSubjectCollection.Add("Project Release Meeting");
            meetingSubjectCollection.Add("Customer Meeting");
            meetingSubjectCollection.Add("Consulting");

            this.colorCollection = new ObservableCollection<Brush>();
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
        }
        private void AddAppointments()
        {
            var today = DateTime.Now;
            var random = new Random();
            for (int month = -1; month < 5; month++)
            {
                for (int day = -15; day < 15; day++)
                {
                    for (int count = 0; count < 1; count++)
                    {
                        var meeting = new Meeting();
                        meeting.EventName = meetingSubjectCollection[random.Next(meetingSubjectCollection.Count)];
                        meeting.color = colorCollection[random.Next(10)];
                        meeting.From = today.AddMonths(month).AddDays(day);
                        meeting.To = meeting.From.AddHours(2);
                        this.Meetings.Add(meeting);
                    }
                }
            }
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    



