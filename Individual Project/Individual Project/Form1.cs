using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Project
{
    public partial class Form1 : Form
    {
        ArrayList eList;
        Event selectedEvent = null;
        bool add = false;
        ArrayList eMList;
        bool month = false;
        public Form1()
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            String dateString = thisDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            label1.Text = "Events on " + dateString;
            eList = Event.getEventList(dateString);
            button6.Visible = false;
            button7.Visible = false;
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle(); ;
                listBox1.Items.Add(aString);
            }
            initializeTimeSections();
        }

        private void initializeTimeSections()
        {
            //textBox2.Visible = false;
            comboBox1.Items.Add("00:00");
            comboBox1.Items.Add("00:30");
            comboBox1.Items.Add("01:00");
            comboBox1.Items.Add("01:30");
            comboBox1.Items.Add("02:00");
            comboBox1.Items.Add("02:30");
            comboBox1.Items.Add("03:00");
            comboBox1.Items.Add("03:30");
            comboBox1.Items.Add("04:00");
            comboBox1.Items.Add("04:30");
            comboBox1.Items.Add("05:00");
            comboBox1.Items.Add("05:30");
            comboBox1.Items.Add("06:00");
            comboBox1.Items.Add("06:30");
            comboBox1.Items.Add("07:00");
            comboBox1.Items.Add("07:30");
            comboBox1.Items.Add("08:00");
            comboBox1.Items.Add("08:30");
            comboBox1.Items.Add("09:00");
            comboBox1.Items.Add("09:30");
            comboBox1.Items.Add("10:00");
            comboBox1.Items.Add("10:30");
            comboBox1.Items.Add("11:00");
            comboBox1.Items.Add("11:30");
            comboBox1.Items.Add("12:00");
            comboBox1.Items.Add("12:30");
            comboBox1.Items.Add("13:00");
            comboBox1.Items.Add("13:30");
            comboBox1.Items.Add("14:00");
            comboBox1.Items.Add("14:30");
            comboBox1.Items.Add("15:00");
            comboBox1.Items.Add("15:30");
            comboBox1.Items.Add("16:00");
            comboBox1.Items.Add("16:30");
            comboBox1.Items.Add("17:00");
            comboBox1.Items.Add("17:30");
            comboBox1.Items.Add("18:00");
            comboBox1.Items.Add("18:30");
            comboBox1.Items.Add("19:00");
            comboBox1.Items.Add("19:30");
            comboBox1.Items.Add("20:00");
            comboBox1.Items.Add("20:30");
            comboBox1.Items.Add("21:00");
            comboBox1.Items.Add("21:30");
            comboBox1.Items.Add("22:00");
            comboBox1.Items.Add("22:30");
            comboBox1.Items.Add("23:00");
            comboBox1.Items.Add("23:30");
            comboBox1.Items.Add("24:00");

            comboBox2.Items.Add("00:00");
            comboBox2.Items.Add("00:30");
            comboBox2.Items.Add("01:00");
            comboBox2.Items.Add("01:30");
            comboBox2.Items.Add("02:00");
            comboBox2.Items.Add("02:30");
            comboBox2.Items.Add("03:00");
            comboBox2.Items.Add("03:30");
            comboBox2.Items.Add("04:00");
            comboBox2.Items.Add("04:30");
            comboBox2.Items.Add("05:00");
            comboBox2.Items.Add("05:30");
            comboBox2.Items.Add("06:00");
            comboBox2.Items.Add("06:30");
            comboBox2.Items.Add("07:00");
            comboBox2.Items.Add("07:30");
            comboBox2.Items.Add("08:00");
            comboBox2.Items.Add("08:30");
            comboBox2.Items.Add("09:00");
            comboBox2.Items.Add("09:30");
            comboBox2.Items.Add("10:00");
            comboBox2.Items.Add("10:30");
            comboBox2.Items.Add("11:00");
            comboBox2.Items.Add("11:30");
            comboBox2.Items.Add("12:00");
            comboBox2.Items.Add("12:30");
            comboBox2.Items.Add("13:00");
            comboBox2.Items.Add("13:30");
            comboBox2.Items.Add("14:00");
            comboBox2.Items.Add("14:30");
            comboBox2.Items.Add("15:00");
            comboBox2.Items.Add("15:30");
            comboBox2.Items.Add("16:00");
            comboBox2.Items.Add("16:30");
            comboBox2.Items.Add("17:00");
            comboBox2.Items.Add("17:30");
            comboBox2.Items.Add("18:00");
            comboBox2.Items.Add("18:30");
            comboBox2.Items.Add("19:00");
            comboBox2.Items.Add("19:30");
            comboBox2.Items.Add("20:00");
            comboBox2.Items.Add("20:30");
            comboBox2.Items.Add("21:00");
            comboBox2.Items.Add("21:30");
            comboBox2.Items.Add("22:00");
            comboBox2.Items.Add("22:30");
            comboBox2.Items.Add("23:00");
            comboBox2.Items.Add("23:30");
            comboBox2.Items.Add("24:00");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            add = true;
            button1.BackColor = Color.Red;
            emptyEventForm();
            textBox2.Visible = false;
            comboBox1.Visible = true;
            comboBox1.SelectedIndex = 0;
            textBox3.Visible = false;
            comboBox2.Visible = true;
            comboBox2.SelectedIndex = 0;
            button6.Visible = true;
            button7.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            monthCalendar1.Enabled = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                string message = "Need a title for the event.";
                string caption = "Missing Title";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            Event newEvent = new Event();
            bool noConflict;
            if (add) {
                        newEvent.updateEventValue(textBox1.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),
                "", textBox5.Text, thisDate, textBox7.Text, 0);
                noConflict = newEvent.checkConflict(eList, add);
            } else
            {
                selectedEvent.updateEventValue(textBox1.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),
                "", textBox5.Text, thisDate, textBox7.Text, selectedEvent.getEventID());
                noConflict = selectedEvent.checkConflict(eList, add);
            };
            if (noConflict == false)
            {
                string message = "The new event has time conflict with some existing event. Please double check starting and ending time";
                string caption = "Error Detected in Time Specification";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            } 
            else
            {
                if (add == true)
                {
                    newEvent.saveEvent();
                    string message = "The new event has been saved to database successfully.";
                    string caption = "New Event Been Saved";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    Button7_Click(sender, e);
                    thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    label1.Text = "Events on " + thisDate;
                    eList = Event.getEventList(thisDate);
                    button6.Visible = false;
                    button7.Visible = false;
                    listBox1.Items.Clear();
                    for (int i = 0; i < eList.Count; i++)
                    {
                        Event currentEvent = (Event)eList[i];
                        String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                        listBox1.Items.Add(aString);
                    }
                    add = false;
                }
                else
                {
                    selectedEvent.editEvent();
                    string message = "The event has been edited in the database successfully.";
                    string caption = "Event Has Been Edited";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    Button7_Click(sender, e);
                    thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    label1.Text = "Events on " + thisDate;
                    eList = Event.getEventList(thisDate);
                    button6.Visible = false;
                    button7.Visible = false;
                    listBox1.Items.Clear();
                    for (int i = 0; i < eList.Count; i++)
                    {
                        Event currentEvent = (Event)eList[i];
                        String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                        listBox1.Items.Add(aString);
                    }
                }
                
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month)
            {
                if (listBox1.SelectedIndex == -1)
                    listBox1.SelectedIndex = 0;
                Event currentEvent = (Event)eMList[listBox1.SelectedIndex];

                selectedEvent = currentEvent;

                panel1.Visible = true;
                textBox1.Text = currentEvent.getTitle();
                textBox2.Text = currentEvent.getStartTime();
                textBox3.Text = currentEvent.getEndTime();
                textBox5.Text = currentEvent.getLocation();
                textBox7.Text = currentEvent.getDescription();
            }
            else
            {
                if (listBox1.SelectedIndex == -1)
                    listBox1.SelectedIndex = 0;
                Event currentEvent = (Event)eList[listBox1.SelectedIndex];

                selectedEvent = currentEvent;

                panel1.Visible = true;
                textBox1.Text = currentEvent.getTitle();
                textBox2.Text = currentEvent.getStartTime();
                textBox3.Text = currentEvent.getEndTime();
                textBox5.Text = currentEvent.getLocation();
                textBox7.Text = currentEvent.getDescription();
            }
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            label1.Text = "Events on " + thisDate;
            eList = Event.getEventList(thisDate);
            button6.Visible = false;
            button7.Visible = false;
            listBox1.Items.Clear();
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
            if (eList.Count == 0)
                selectedEvent = null;
            else
                selectedEvent = (Event) eList[0];
        }

        private void emptyEventForm()
        {
            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            if (month)
            {
                month = false;
                listBox1.Items.Clear();
                DateTime thisDay = DateTime.Today;
                String dateString = thisDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                label1.Text = "Events on " + dateString;
                eList = Event.getEventList(dateString);
                for (int i = 0; i < eList.Count; i++)
                {
                    Event currentEvent = (Event)eList[i];
                    String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle(); ;
                    listBox1.Items.Add(aString);
                }
                if(listBox1.Items.Count > 0)
                    listBox1.SelectedIndex = 0;
                monthCalendar1.SetDate(thisDay);
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            monthCalendar1.Enabled = true;
            button1.BackColor = DefaultBackColor;
            button2.BackColor = DefaultBackColor;
            button4.BackColor = DefaultBackColor;
            button5.BackColor = DefaultBackColor;
            button6.Visible = false;
            button7.Visible = false;
            textBox2.Visible = true;
            comboBox1.Visible = false;
            textBox3.Visible = true;
            comboBox2.Visible = false;
            if (eList.Count != 0)
            {
                ListBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                emptyEventForm();
            }
            if (listBox1.Items.Count == 0)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null)
            {
                message = "There is no event selected.";
                caption = "Error: No event been seletced";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                button2.BackColor = Color.Red;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                message = "Do you really want to delete this event?";
                caption = "Delete Event";
                buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    selectedEvent.deleteEvent();
                    Button7_Click(sender, e);
                    label1.Text = "Events on " + thisDate;
                    eList = Event.getEventList(thisDate);
                    button6.Visible = false;
                    button7.Visible = false;
                    listBox1.Items.Clear();
                    for (int i = 0; i < eList.Count; i++)
                    {
                        Event currentEvent = (Event)eList[i];
                        String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                        listBox1.Items.Add(aString);
                    }

                }
                button2.BackColor = DefaultBackColor;
                Button7_Click(sender, e);
            }
            
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            add = false;
            button4.BackColor = Color.Red;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            monthCalendar1.Enabled = false;
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null)
            {
                message = "There is no event selected to edit.";
                caption = "Error: No event been seletced to edit";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                Button7_Click(sender, e);
            }
            else
            {
                message = "Do you want to edit this event?";
                caption = "Edit Event";
                buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    button6.Visible = true;
                    button7.Visible = true;
                    textBox2.Visible = false;
                    int comboIndex = 0;

                    //set the first combo box to the current value

                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        string comboText = comboBox1.GetItemText(comboBox1.Items[i]);
                        if (textBox2.Text == comboText)
                        {
                            comboIndex = i;
                        }
                    }
                    comboBox1.SelectedIndex = comboIndex;
                    comboBox1.Visible = true;
                    //set the second combo box to the current value

                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        string comboText = comboBox2.GetItemText(comboBox2.Items[i]);
                        if (textBox3.Text == comboText)
                        {
                            comboIndex = i;
                        }
                    }
                    comboBox2.SelectedIndex = comboIndex;
                    comboBox2.Visible = true;
                    textBox3.Visible = false;
                    button6.Visible = true;
                    button7.Visible = true;
                }
                else
                {
                    Button7_Click(sender, e);
                }

            }
    }

        private void button5_Click(object sender, EventArgs e)
        {
            month = true;
            String thisMonth = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-");
            String monthName = monthCalendar1.SelectionRange.Start.ToString("MM");
            monthCalendar1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            switch (monthName)
            {
                case "01":
                    monthName = "January";
                    break;
                case "02":
                    monthName = "February";
                    break;
                case "03":
                    monthName = "March";
                    break;
                case "04":
                    monthName = "April";
                    break;
                case "05":
                    monthName = "May";
                    break;
                case "06":
                    monthName = "June";
                    break;
                case "07":
                    monthName = "July";
                    break;
                case "08":
                    monthName = "August";
                    break;
                case "09":
                    monthName = "September";
                    break;
                case "10":
                    monthName = "October";
                    break;
                case "11":
                    monthName = "November";
                    break;
                case "12":
                    monthName = "December";
                    break;
                default:
                    break; 
            }
            label1.Text = monthName+"'s"+" Events";
            eMList = Event.getMonthEventList(thisMonth);
            Console.WriteLine("Made eMList");
            button6.Visible = false;
            button7.Visible = true;
            listBox1.Items.Clear();
            for (int i = 0; i < eMList.Count; i++)
            {
                Event currentEvent = (Event)eMList[i];
                Console.WriteLine(currentEvent.getTitle());
                String aString = currentEvent.getDate() +" " + currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
            if (eMList.Count == 0)
                selectedEvent = null;
            else
                selectedEvent = (Event)eMList[0];
            
            panel1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
