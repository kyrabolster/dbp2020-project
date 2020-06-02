SELECT CourseId, Course.InstructorId, CourseTitle, LastName + ', ' + FirstName AS Instructor FROM Course 
	INNER JOIN Instructor
		ON Course.InstructorID = Instructor.InstructorID
ORDER BY CourseTitle;


SELECT * FROM Course;