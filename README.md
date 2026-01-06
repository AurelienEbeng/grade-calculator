# General Application Requirements
- The application shall allow a teacher to enter student information through form input fields.
- The application shall validate all user input using Regular Expressions.
- The application shall save valid student data to a text file.
- The application shall generate an XML file based on the text file data.
- The application shall read and display the content of the generated XML file.

# Grade Management (FGrades Class)
- The system shall store evaluation data using private fields with public properties.
- The system shall support multiple constructors (default, one-parameter, two-parameter, and three-parameter).
- The system shall calculate the total grade as a percentage using weighted evaluations:
    - Midterm: 30%
    - Project: 30%
    - Final: 40%
- The system shall calculate and return:
    - The total numeric grade.
    - The letter grade based on the following scale:
        - 90–100: A
        - 80–89.9: B
        - 70–79.9: C
        - 60–69.9: D
        - 0–59.9: F
    - Other values: NaG (Not a Grade)
- The system shall calculate the percentage contribution of each evaluation.

# Validation Requirements (Validator Class)
- The system shall validate the academic year to accept values between 2020 and 2029.
- The system shall validate the session input to accept only Fall, Winter, or Summer.
- The system shall validate numeric grade inputs to accept values consisting of one, two, or three digits.

# Form 1 Functional Requirements
- The system shall provide a button to open the second form.
- The system shall provide a button to exit the application with confirmation (OK/Cancel dialog with question icon).

# Form 2 Functional Requirements
- The system shall allow users to:
    - Create student and grade objects.
    - Validate input data.
    - Calculate and display the total grade.
- The system shall prevent modification of the total grade after it is calculated and displayed.
- The system shall write student data to a text file with one student per line.
- The system shall store text file data using the pipe (|) character as a delimiter.
- The system shall generate an XML file from the text file data.
- The system shall display an error message if XML generation fails.
- The system shall read and display XML file contents in a message box.
- The system shall close the form with confirmation (OK/Cancel dialog with question icon).

# File and Folder Management
- The system shall create a folder named S2023 if it does not exist when Form 2 loads.
- The system shall save student data to ./S2023/FExam.txt.
- The system shall generate the XML file ./S2023/FExam.xml using the text file as input.

# Data Entry Rules
- The system shall accept grade values between 0 and 100 inclusive for all evaluations.
- The system shall test and handle various input formats to ensure correct functionality.


# Technology Used
- C#
- Windows Form

Checkout the demo on [LinkedIn](https://www.linkedin.com/feed/update/urn:li:activity:7414314113688043520/)
