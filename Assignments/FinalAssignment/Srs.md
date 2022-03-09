# Software requirement specification

---
## I.Introduction.
1. Purpose.
- This product is aimed to solve:
  - Teachers have to enter student grade one by one to the system which lead to hugh problem of time  consuming.
  - Admin need to check and schedule for students the classes that students can take next term. To achieve that, the admin need to manually check if the student passed the prerequisites and what prerequisite that the next course have.
  This process takes a hugh amount of time since they have to do this for every students in the program.
2. Intended Audiences.
- Teachers
- Admins or people who responsible for enroll students to their upcoming courses.
3.Scope
- Objective: 
   - Helping teachers and admin to save their time scheduling students courses and entering grade fast and more convenient
- Benefits:
   - Teachers and admins can save their time.
- Business Goal:
   - Provide a reliable platform/tool that teachers and admin can use for their work.
## II. Overall Description
1. User needs. 
- save, edit, delete, search and list the student
- For students who are registered in a specific degree, diploma or certificate program, audiences want an application that provides the students with available and enroll able courses for a term
- Available means that the course is going to run on a specific date/time(year, semester)
- Enroll able means that based on students previous courses give the courses which the student can enroll in.
2. Assumption and dependencies.
- The product will be build on UWP(universal windows platform)-WinUi2. However Microsoft will stop focusing on UWP on december of this year. Our team will consider migrate to WinUi3(new platform) if required.
## III.Systems features and requirements
1. Functional requirements.
- Admin and user Signin/out function
- Connect to the school database and get the latest students info(will be provided by the teacher)
- Modify student information
- Suggest next possible courses that students can take
- Enter grade by importing csv(other file type can be consider in future)
2. External interface requirement.
- Hardware interfaces:
  - Product will be built and run on Windows machine(desktop or laptop)
- Software interfaces: 
  - Language use: C#
  - Framework: .net core
  - Database server: MariaDB
  - Platform: UWP(universal windows platform)
  - OS: Windows operating system.
  - App type: Desktop app.
- Communication interfaces:
  - Product will communicate with database server through tcp protocol
  - Product is built using 3 tier architecture(Data access layer, business layer, presentation layer), each layer will communicate with each other through a layer called shared.
3. Other nonfunctional requirements.
   - Performance: The app should run and always receive the required information.
   - Security and safety: Ensure only admin and teachers who are authorized can use it.
