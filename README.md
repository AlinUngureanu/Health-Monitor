# Health-Monitor

The application is a health monitoring system that aims to remotely monitor the health parameters (such as heart rate, skin temperature and blood glucose) of patients who are at home. Key features include:

1. **Sensor simulation:** Since the app is designed to monitor patients remotely, in the absence of physical sensors, it uses simulation to generate data that would mimic the behavior of real sensors. Thus, random generation functions produce values ​​in predetermined ranges for critical patient health parameters such as:
   - Heart rate (for example, between 60-100 beats per minute)
   - Skin temperature (between 36°C and 40°C)
   - Blood glucose (between 80 and 300 mg/dL)
<endl>

2. **Data acquisition and storage:** The system collects this data and periodically saves it to a SQL Server database. This storage method ensures that data is preserved for later analysis and allows the doctor to access a patient's measurement history, even after closing the application.
3. **Data transmission:** An important part of the application is the transmission of data from the patient's home to the doctor's office. This functionality is achieved using TCP/IP, which allows real-time data transfer, simulating a stable connection between patient and doctor.
4. **Data display and analysis:** In the doctor's office, the app receives data from patient sensors and displays it in an intuitive graphical interface. The doctor can view the values ​​as they are received and quickly identify if the patient's parameters are outside the normal limits. In addition, the application can generate alarms when it detects critical values, allowing for immediate intervention.

