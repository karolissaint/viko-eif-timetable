CREATE TABLE [Group] (
	Id integer(5) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_GROUP] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [SubGroup] (
	Id integer(1) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_SUBGROUP] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [LectureNumber] (
	Id integer(5) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_LECTURENUMBER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Time] (
	id integer(5) NOT NULL,
	StartTime time NOT NULL,
	EndTime time NOT NULL,
  CONSTRAINT [PK_TIME] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [DayOfTheWeek] (
	Id integer(1) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_DAYOFTHEWEEK] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TimeTable] (
	Id integer(5) NOT NULL,
	NumberOfWeek integer(1) NOT NULL,
	SubGroupId integer(1) NOT NULL,
	GroupId integer(5) NOT NULL,
	LecturerId integer(5) NOT NULL,
	CabinetId integer(5) NOT NULL,
	LectureTitleId integer(5) NOT NULL,
  CONSTRAINT [PK_TIMETABLE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Lecturer] (
	Id integer(5) NOT NULL,
	Name string(20) NOT NULL,
	LastName string(20) NOT NULL,
	LecturePostId integer(5) NOT NULL,
  CONSTRAINT [PK_LECTURER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [LecturerPost] (
	Id integer(5) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_LECTURERPOST] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Cabinet] (
	Id integer(5) NOT NULL,
	Code string(4) NOT NULL,
  CONSTRAINT [PK_CABINET] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [LectureTitle] (
	Id integer(5) NOT NULL,
	Title string(20) NOT NULL,
  CONSTRAINT [PK_LECTURETITLE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [LectureTime] (
	Id integer(5) NOT NULL,
	DayOfTheWeekId integer(1) NOT NULL,
	TimeId integer(5) NOT NULL,
	LectureNumberId integer(5) NOT NULL,
	TimeTableId integer(5) NOT NULL,
	Notice string,
  CONSTRAINT [PK_LECTURETIME] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO





ALTER TABLE [TimeTable] WITH CHECK ADD CONSTRAINT [TimeTable_fk4] FOREIGN KEY ([LectureTitleId]) REFERENCES [LectureTitle]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TimeTable] CHECK CONSTRAINT [TimeTable_fk4]
GO

ALTER TABLE [Lecturer] WITH CHECK ADD CONSTRAINT [Lecturer_fk0] FOREIGN KEY ([LecturePostId]) REFERENCES [LecturerPost]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Lecturer] CHECK CONSTRAINT [Lecturer_fk0]
GO




ALTER TABLE [LectureTime] WITH CHECK ADD CONSTRAINT [LectureTime_fk3] FOREIGN KEY ([TimeTableId]) REFERENCES [TimeTable]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [LectureTime] CHECK CONSTRAINT [LectureTime_fk3]
GO

