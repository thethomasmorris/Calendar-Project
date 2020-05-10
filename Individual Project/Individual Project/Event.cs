using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Project
{
    class Event
    {
        String title;
        String startTime;
        String endTime;
        String reminder;
        String location;
        String date;
        String description;
        String empID = "1";
        User[] attendees;
        int eventID;


        public Event(String t, String st, String et, String r, String l, String d, String ds)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = r;
            location = l;
            date = d;
            description = ds;
        }

        public Event()
        {

        }


        public void saveEvent()
        {
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO morrisevent (title, date, starttime, endtime, reminder, description, location, empid) " + 
                    "VALUES (@title, @date, @startTime, @endTime, @reminder, @description, @location, @empid)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@reminder", "");
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@empid", empID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
        public bool checkConflict(ArrayList eList, bool add)
        {
            if (add)
            {
                if (eList.Count == 0)
                {

                    return true;
                }
                if(startTime.CompareTo(endTime) > 0)
                {
                    //check that start time is before end time
                    return false;
                }
                for (int i = 0; i < eList.Count; i++)
                {
                    Event thisEvent = (Event)eList[i];
                    if (startTime.CompareTo(thisEvent.getEndTime()) >= 0 || endTime.CompareTo(thisEvent.getStartTime()) <= 0)
                    {
                        continue;
                    } 
                    else
                        return false;
                }
                return true;
            }
            else
            {
                if (startTime.CompareTo(endTime) > 0)
                {
                    //check that start time is before end time
                    return false;
                }
                for (int i = 0; i < eList.Count; i++)
                {
                    Event thisEvent = (Event)eList[i];
                    Console.WriteLine(this.eventID + " " + thisEvent.getEventID());
                    if (startTime.CompareTo(thisEvent.getEndTime()) >= 0 || endTime.CompareTo(thisEvent.getStartTime()) <= 0)
                    {
                        continue;
                    }
                    else if(thisEvent.getEventID() == this.eventID)
                    {
                        continue;
                    }
                    else
                        return false;
                }
                return true;
            }
            
        }


        public void updateEventValue(String t, String st, String et, String r, String l, String d, String ds, int eid)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = "";
            location = l;
            date = d;
            description = ds;
            eventID = eid;
        }
        public String getStartTime()
        {
            return startTime;
        }

        public String getEndTime()
        {
            return endTime;
        }

        public String getReminder()
        {
            return "";
        }

        public String getLocation()
        {
            return location;
        }
        public String getTitle()
        {
            return title;
        }

        public String getDescription()
        {
            return description;
        }

        public int getEventID()
        {
            return this.eventID;
        }

        public String getDate()
        {
            return date.Substring(0,9);
        }

        public static ArrayList getEventList(string dateString)
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM morrisEvent WHERE date=@myDate AND empid='1' ORDER BY startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = "";
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }

        public static ArrayList getMonthEventList(string dateString)
        {
            Console.WriteLine(dateString);
            dateString = dateString+"%%";
            ArrayList eventMonthList = new ArrayList();  //a list to save the events for month
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM morrisevent WHERE date LIKE @myDate AND empid='1' ORDER BY startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = "";
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                eventMonthList.Add(newEvent);
                Console.WriteLine(newEvent.title);
            }
            Console.WriteLine("Made it to return eventMonthList");
            return eventMonthList;  //return the event list
        }

        public void deleteEvent()
        {
            Console.WriteLine("ID of deleted event: " + this.eventID);

            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM morrisevent WHERE eventid = @eventID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", this.eventID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            
        }
        public void editEvent()
        {
            Console.WriteLine("ID of edit event: " + this.eventID);

            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE morrisevent SET title = @title, date = @date, startTime = @startTime, endTime = @endTime, reminder = @reminder, description = @description, location = @location WHERE eventID = @eventID";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@reminder", "");
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@empid", empID);
                cmd.Parameters.AddWithValue("@eventID", this.eventID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

    }
}
