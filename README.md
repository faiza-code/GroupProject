

<h1 style="text-align:center; background: linear-gradient(90deg, #1E90FF, #00BFFF); color:white; padding:20px; border-radius:15px; text-shadow: 2px 2px 5px #555;">
EduTrack Oman – Training Center Management System
</h1>

---

<div style="background-color:#f0f8ff; padding:20px; border-left: 8px solid #1E90FF; border-radius:10px; box-shadow: 3px 3px 10px #aaa;">
<h2>📖 Project Overview</h2>
<p><b>EduTrack Oman</b> is a training center in Muscat offering technical and soft skills courses for fresh graduates and working professionals. Currently, all processes are <b>manual</b> (Excel sheets, paper attendance, handwritten receipts).</p>
<p>This project <b>digitizes the workflow</b> to efficiently manage <b>students, trainers, courses, enrollments, and payments</b>.</p>
</div>

---

<div style="background-color:#e6ffe6; padding:20px; border-left: 8px solid #32CD32; border-radius:10px; box-shadow: 3px 3px 10px #aaa;">
<h2>🎯 Objectives</h2>
<ul>
<li>Automate <b>student registration</b> and <b>course enrollment</b></li>
<li>Track <b>payments</b> and <b>outstanding balances</b></li>
<li>Assign trainers to courses and manage their <b>workload</b></li>
<li>Generate <b>reports</b> for enrollment, revenue, and top-performing students</li>
<li>Enforce <b>business rules</b> for scheduling and discounts</li>
</ul>
</div>

---

<h2 style="color:#FF6347;">🏛 Entities & Relationships</h2>

<h3 style="color:#1E90FF;">1. Students</h3>
<table style="width:100%; border-collapse:collapse; box-shadow: 2px 2px 8px #aaa;">
<tr style="background-color:#f0f8ff;">
<th>Attribute</th><th>Type</th><th>Notes</th>
</tr>
<tr><td>StudentID</td><td>PK</td><td>Unique identifier</td></tr>
<tr><td>Full Name</td><td>Text</td><td></td></tr>
<tr><td>Civil ID</td><td>Text</td><td>Unique</td></tr>
<tr><td>Phone</td><td>Text</td><td></td></tr>
<tr><td>Email</td><td>Text</td><td></td></tr>
<tr><td>City</td><td>Text</td><td></td></tr>
<tr><td>Registration Date</td><td>Date</td><td></td></tr>
</table>
<p><b>Relationships:</b> Many-to-Many with <b>Courses</b> via <b>Enrollments</b></p>

<h3 style="color:#1E90FF;">2. Trainers</h3>
<table style="width:100%; border-collapse:collapse; box-shadow: 2px 2px 8px #aaa;">
<tr style="background-color:#f0f8ff;">
<th>Attribute</th><th>Type</th><th>Notes</th>
</tr>
<tr><td>TrainerID</td><td>PK</td><td>Unique identifier</td></tr>
<tr><td>Name</td><td>Text</td><td></td></tr>
<tr><td>Specialty</td><td>Text</td><td>e.g., Programming</td></tr>
<tr><td>YearsOfExperience</td><td>Int</td><td></td></tr>
<tr><td>Phone</td><td>Text</td><td></td></tr>
<tr><td>Email</td><td>Text</td><td></td></tr>
</table>
<p><b>Relationships:</b> One-to-Many with <b>Courses</b></p>

<h3 style="color:#1E90FF;">3. Courses</h3>
<table style="width:100%; border-collapse:collapse; box-shadow: 2px 2px 8px #aaa;">
<tr style="background-color:#f0f8ff;">
<th>Attribute</th><th>Type</th><th>Notes</th>
</tr>
<tr><td>CourseID</td><td>PK</td><td>Unique identifier</td></tr>
<tr><td>Title</td><td>Text</td><td>Course name</td></tr>
<tr><td>Category</td><td>Text</td><td>Programming, Design, English, Business</td></tr>
<tr><td>Duration</td><td>Int</td><td>In hours</td></tr>
<tr><td>StartDate</td><td>Date</td><td></td></tr>
<tr><td>EndDate</td><td>Date</td><td></td></tr>
<tr><td>Fee</td><td>Decimal</td><td></td></tr>
<tr><td>TrainerID</td><td>FK</td><td>Assigned trainer</td></tr>
</table>

<h3 style="color:#1E90FF;">4. Enrollments</h3>
<table style="width:100%; border-collapse:collapse; box-shadow: 2px 2px 8px #aaa;">
<tr style="background-color:#f0f8ff;">
<th>Attribute</th><th>Type</th><th>Notes</th>
</tr>
<tr><td>EnrollmentID</td><td>PK</td><td>Unique identifier</td></tr>
<tr><td>StudentID</td><td>FK</td><td>Reference Students</td></tr>
<tr><td>CourseID</td><td>FK</td><td>Reference Courses</td></tr>
<tr><td>EnrollmentDate</td><td>Date</td><td></td></tr>
<tr><td>Status</td><td>Enum</td><td><code>Active, Completed, Cancelled</code></td></tr>
<tr><td>Grade</td><td>Text</td><td>Optional</td></tr>
</table>
<p><b>Relationships:</b> Links <b>Students ↔ Courses</b> (Many-to-Many)</p>

<h3 style="color:#1E90FF;">5. Payments</h3>
<table style="width:100%; border-collapse:collapse; box-shadow: 2px 2px 8px #aaa;">
<tr style="background-color:#f0f8ff;">
<th>Attribute</th><th>Type</th><th>Notes</th>
</tr>
<tr><td>PaymentID</td><td>PK</td><td>Unique identifier</td></tr>
<tr><td>EnrollmentID</td><td>FK</td><td>Reference Enrollments</td></tr>
<tr><td>AmountPaid</td><td>Decimal</td><td></td></tr>
<tr><td>PaymentDate</td><td>Date</td><td></td></tr>
<tr><td>PaymentMethod</td><td>Enum</td><td><code>Cash, Card, Bank Transfer</code></td></tr>
<tr><td>RemainingBalance</td><td>Decimal</td><td></td></tr>
</table>

---

<div style="background: linear-gradient(90deg, #FF4500, #FF6347); padding:20px; border-radius:10px; box-shadow: 3px 3px 10px #888;">
<h2 style="color:white;">⚖ Business Rules</h2>
<ol style="color:white;">
<li>Students cannot enroll in courses with overlapping schedules.</li>
<li>Trainers cannot handle more than <b>3 active courses</b> simultaneously.</li>
<li>Students with <b>3+ completed courses</b> get a <b>10% discount</b> on new enrollments.</li>
<li>Each payment must correspond to an existing enrollment.</li>
</ol>
</div>

<div style="background: linear-gradient(90deg, #32CD32, #98FB98); padding:20px; border-radius:10px; box-shadow: 3px 3px 10px #888;">
<h2>📊 Reports & Insights</h2>
<ul>
<li>Current Enrollment: List of students per course</li>
<li>Revenue Reports: Total revenue per course</li>
<li>Top Students: Top 3 students with the most completed courses</li>
</ul>
</div>

<div style="background-color:#f0f8ff; padding:20px; border-radius:10px; box-shadow: 3px 3px 10px #aaa;">
<h2>🔗 ERD & Relational Schema</h2>
<p align="center">
<img src="https://i.postimg.cc/858zvNjS/erdplus.png" alt="ERD Diagram" style="border-radius:10px; box-shadow:5px 5px 15px #888; width:80%; max-width:100%;">
</p>
<p align="center">
<img src="https://i.postimg.cc/ZqVw9MCs/erdplus-1.png" alt="Relational Schema" style="border-radius:10px; box-shadow:5px 5px 15px #888; width:80%; max-width:100%;">
</p>
</div>

<div style="background-color:#e6f0ff; padding:20px; border-left: 8px solid #1E90FF; border-radius:10px; box-shadow: 3px 3px 10px #aaa;">
<h2>🛠 Technologies Used</h2>
<ul>
<li><b>Database:</b> MySQL / PostgreSQL</li>
<li><b>Backend:</b> PHP / Python / Node.js</li>
<li><b>Frontend:</b> HTML, CSS, JavaScript</li>
<li><b>Reporting:</b> Excel / Power BI (optional)</li>
</ul>
</div>

<div style="background-color:#ffe6e6; padding:20px; border-left: 8px solid #FF4500; border-radius:10px; box-shadow: 3px 3px 10px #aaa;">
<h2>🚀 How to Use</h2>
<ol>
<li>Register students before enrollment.</li>
<li>Assign trainers to courses (max 3 active courses per trainer).</li>
<li>Create enrollments and record payments.</li>
<li>Generate reports for management insights.</li>
</ol>
</div>

<div style="background: linear-gradient(90deg, #FF6347, #FF4500); padding:20px; border-radius:10px; box-shadow: 3px 3px 10px #888;">
<h2 style="color:white;">✅ Conclusion</h2>
<p style="color:white;">The <b>EduTrack Oman – Training Center Management System</b> delivers a modern, efficient solution to automate student, trainer, course, and payment management.</p>
<ul style="color:white;">
<li>Streamlined student registration and course enrollment</li>
<li>Accurate tracking of payments and balances</li>
<li>Enforcement of scheduling and business rules</li>
<li>Insightful reports for revenue, course performance, and top students</li>
</ul>
<p style="color:white;">This system empowers EduTrack Oman to <b>save time, reduce errors, and enhance the experience</b> for students, trainers, and staff. Future enhancements could include <b>online course access</b> and <b>analytics dashboards</b>.</p>
</div>
<div style="background: linear-gradient(90deg, #1E90FF, #00BFFF); padding:20px; border-radius:10px; text-align:center; color:white; box-shadow: 3px 3px 10px #888; margin-top:20px;">
<h2>📌 Final Statement</h2>
<p>The <b>EduTrack Oman – Training Center Management System</b> represents a transformative solution for managing students, trainers, courses, and payments. Through this system, the following has been achieved:</p>
<ul style="text-align:left; display:inline-block; margin-top:10px;">
<li>Streamlined student registration and course enrollment</li>
<li>Accurate tracking of payments and outstanding balances</li>
<li>Automatic enforcement of business rules to prevent schedule conflicts</li>
<li>Clear analytical reports on revenue, student performance, and course effectiveness</li>
</ul>
<p style="margin-top:10px;">This system helps <b>save time, reduce errors, and enhance the experience</b> for students, trainers, and staff. It also provides a strong foundation for future enhancements, such as <b>online course access</b> and <b>analytics dashboards</b> to support strategic decision-making.</p>
</div>

## 👩🏻‍💻 Team 3 
Name of Members:
<br>
**Raya Al Amri**  
**Faiza ALHandali**  
**Leema Al Raai**  
**Duaa Al Dahab**  
**Asma Al-Alawi**  

<p align="center"><b>✨ “Deliver efficiently, track effectively, and structure your code with OOP.” ✨</b></p>


