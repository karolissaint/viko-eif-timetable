using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TimeTable.BL.DataHelpers
{
    public class LectureTitle {
        public int id { get; set; }
        public string title { get; set; }
    }
    public class LectureTitleDataHelper
    {
        private static readonly string LECTURE_TITLE_TABLE = "[LectureTitle]";

        private static readonly string KEY_ID = "Id"; // in database set auto increment 1
        private static readonly string KEY_TITLE = "Title";

        private SqlCommand insertCmd;
        private static readonly string INSERT = "insert into " + LECTURE_TITLE_TABLE + "(" + KEY_TITLE + ")" +
            " values(@" + KEY_TITLE + ")";

        private SqlCommand updateCmd;
        private static readonly string UPDATE = "update " + LECTURE_TITLE_TABLE + "set " + KEY_TITLE + " = @" +
            KEY_TITLE + " where " + KEY_ID + " = @" + KEY_ID;

        private SqlCommand deleteCmd;
        private static readonly string DELETE = "delete from " + LECTURE_TITLE_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectCmd;
        private static readonly string SELECT = "select * from " + LECTURE_TITLE_TABLE + " where " + KEY_TITLE + " = @" + KEY_TITLE;

        private SqlCommand selectAllCmd;
        private static readonly string SELECT_ALL = "select * from " + LECTURE_TITLE_TABLE;

        public LectureTitleDataHelper()
        {
            this.insertCmd = Database.compileCommand(INSERT);
            this.updateCmd = Database.compileCommand(UPDATE);
            this.deleteCmd = Database.compileCommand(DELETE);
            this.selectCmd = Database.compileCommand(SELECT);
            this.selectAllCmd = Database.compileCommand(SELECT_ALL);
        }

        public string insert(LectureTitle lectureTitle)
        {
            if (lectureTitle.title == "" || string.IsNullOrWhiteSpace(lectureTitle.title)) return "Lecture title can't be empty!";
            if (isExists(lectureTitle.title)) return "Lecture title already exist!";
            insert(lectureTitle.title);
            return null;
        }
        private void insert(string title)
        {
            this.insertCmd.Parameters.Clear();
            this.insertCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            insertCmd.ExecuteNonQuery();
        }

        public string update(LectureTitle lectureTitle)
        {
            if (lectureTitle.title == "" || string.IsNullOrWhiteSpace(lectureTitle.title)) return "Lecture title can't be empty!";
            update(lectureTitle.id, lectureTitle.title);
            return null;
        }
        private void update(int id, string title)
        {
            this.updateCmd.Parameters.Clear();
            this.updateCmd.Parameters.AddWithValue("@" + KEY_ID, id);
            this.updateCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            updateCmd.ExecuteNonQuery();
        }

        public void delete(string title)
        {
            this.deleteCmd.Parameters.Clear();
            this.deleteCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            deleteCmd.ExecuteNonQuery();
        }

        public void deleteAll()
        {
            Database.delete(LECTURE_TITLE_TABLE);
        }

        public LectureTitle getByTitle(LectureTitle lectureTitle)
        {
            return getByTitle(lectureTitle.title);
        }
        private LectureTitle getByTitle(string title)
        {
            this.selectCmd.Parameters.Clear();
            LectureTitle lectureTitle = new LectureTitle();
            this.selectCmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            using (SqlDataReader reader = this.selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lectureTitle.id = Convert.ToInt32(reader[0]);
                    lectureTitle.title = reader[1].ToString();
                }
            }
            return lectureTitle;
        }

        public List<LectureTitle> getAll()
        {
            List<LectureTitle> lectureTitles = new List<LectureTitle>();
            using (SqlDataReader reader = this.selectAllCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lectureTitles.Add(new LectureTitle()
                    {
                        id = Convert.ToInt32(reader[0]),
                        title = reader[1].ToString(),
                    });
                }
            }
            return lectureTitles;
        }

        public bool isExists(string title)
        {
            SqlCommand cmd = Database.compileCommand("select count(*) from " + LECTURE_TITLE_TABLE + " where " + KEY_TITLE + " =@" + KEY_TITLE);
            cmd.Parameters.AddWithValue("@" + KEY_TITLE, title);
            int weeksCount = (int)cmd.ExecuteScalar();
            if (weeksCount > 0) return true;
            return false;
        }
    }
}
