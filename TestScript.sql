SELECT CourseId, Course.InstructorId, CourseTitle, LastName + ', ' + FirstName AS Instructor FROM Course 
	INNER JOIN Instructor
		ON Course.InstructorID = Instructor.InstructorID
ORDER BY CourseTitle;


SELECT * FROM Course;

-- get courses students
SELECT Course.CourseID, CourseTitle,
	Student.LastName + ', ' + Student.FirstName AS [Student Name],
	Student.Email
FROM Course
	INNER JOIN StudentCourse
		ON Course.CourseId = StudentCourse.CourseId
	INNER JOIN Student
		ON Student.StudentID = StudentCourse.StudentId
	WHERE Course.CourseID = 11
	ORDER BY CourseTitle
	
SELECT Student.LastName + ', ' + Student.FirstName AS [Student Name],
	Student.Email
FROM Course
	INNER JOIN StudentCourse
		ON Course.CourseId = StudentCourse.CourseId
	INNER JOIN Student
		ON Student.StudentID = StudentCourse.StudentId
	WHERE Course.CourseID = 11
	ORDER BY CourseTitle

	--get student's courses
	SELECT Course.CourseId, CourseTitle, Instructor.LastName + ', ' + Instructor.FirstName AS [Instructor], Campus
            FROM Course
	            INNER JOIN StudentCourse
		            ON Course.CourseId = StudentCourse.CourseId
	            INNER JOIN Student
		            ON Student.StudentID = StudentCourse.StudentId
				INNER JOIN Instructor
					ON Instructor.InstructorId = Course.InstructorId
	            WHERE Student.StudentId = 30
	            ORDER BY CourseTitle

				SELECT StudentID, LastName + ', ' + FirstName AS [StudentName] FROM Student ORDER BY LastName, FirstName