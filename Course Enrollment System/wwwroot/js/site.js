const forms = document.querySelectorAll('#StudentForm, #CourseForm');

forms.forEach(form => {
    form.addEventListener('submit', function (event) {

        if (form.id === 'StudentForm') {
            const nameInput = document.getElementById("Name");
            if (nameInput.value.trim() === "") {
                alert("Name is required");
                event.preventDefault();
                return;
            }

            const ageInput = document.getElementById("Age");
            if (ageInput.value.trim() === "" || isNaN(ageInput.value) || Number(ageInput.value) < 1) {
                alert("Age must be a positive number");
                event.preventDefault();
                return;
            }

            const genderInput = document.getElementById("Gender");
            if (genderInput.value.trim() === "") {
                alert("Gender is required");
                event.preventDefault();
                return;
            }

            const contactInput = document.getElementById("ContactNumber");
            if (contactInput.value.trim() === "") {
                alert("Contact number is required");
                event.preventDefault();
                return;
            }

            const emailInput = document.getElementById("Email");
            if (emailInput.value.trim() === "") {
                alert("Email is required");
                event.preventDefault();
                return;
            }

            const enrollmentDateInput = document.getElementById("EnrollmentDate");
            if (enrollmentDateInput.value.trim() === "") {
                alert("Enrollment date is required");
                event.preventDefault();
                return;
            }
        }

        if (form.id === 'AddCourseForm') {
            const courseNameInput = document.getElementById("CourseName");
            if (courseNameInput.value.trim() === "") {
                alert("Course name is required");
                event.preventDefault();
                return;
            }

            const instructorInput = document.getElementById("Instructor");
            if (instructorInput.value.trim() === "") {
                alert("Instructor is required");
                event.preventDefault();
                return;
            }

            const durationInput = document.getElementById("Duration");
            if (durationInput.value.trim() === "" || isNaN(durationInput.value) || Number(durationInput.value) < 1) {
                alert("Duration must be a positive number");
                event.preventDefault();
                return;
            }

            const creditInput = document.getElementById("Credits");
            if (creditInput.value.trim() === "" || isNaN(creditInput.value) || Number(creditInput.value) < 1) {
                alert("Credits must be a positive number");
                event.preventDefault();
                return;
            }

            const feeInput = document.getElementById("Fee");
            if (feeInput.value.trim() === "" || isNaN(feeInput.value) || Number(feeInput.value) < 0) {
                alert("Fee must be a positive number");
                event.preventDefault();
                return;
            }
        }
        
    });
});