namespace PS.Models
{
    public static class Messages
    {
        public const string PatientNotAllowedToGetOtherPatients =
            "As a patient, you are NOT allowed to view other patients' personal information";

        public const string PatientNotAllowedToSubmitNewPatient =
            "As a patient you are not allowed to submit new patients into the system";

        public const string PatientNotAllowedToModifyOtherPatients =
            "As a patient, you are not allowed to modify other patients' personal information";

        public const string OnlyAdministratorCanExecute = "Only administrators are allowed to execute the requested operation";

        public const string DoctorNotAllowedToSubmitNewDoctor =
            "As a doctor, you are not allowed to submit new doctors into the system";

        public const string PatientNotAllowedToExecute = "As a patient, you are not allowed to execute this operation";

        public const string DoctorNotAllowedToModifyOtherDoctors =
            "As a doctor, you are not allowed to modify other doctors' personal information";

        public const string HospitalNotAllowedToModifyOtherHospitals =
            "As a hospital user, you are not allowed to modify other hospitals' personal information";

        public const string TalkToDoctorToCreateReservation =
            "In order to make a reservation, you need to talk to the doctor and he'll create one for you";

        public const string DoctorNotPartOfHospitalForReservations =
            "The specified doctor is not part of the specified hospital, therefore reservations on his name in that hospital cannot exist";

        public const string TalkToDoctorToUpdateReservation =
            "In order to change a reservation, you need to talk to the doctor and he'll update it for you";

        public const string TalkToDoctorToCancelReservation =
            "In order to cancel a reservation, you need to talk to the doctor and he'll cancel it for you";

        public const string DoctorNotAllowedToPostReservationOnOtherDoctors =
            "As a doctor, you are not allowed to post reservations on other doctors";

        public const string HospitalNotAllowedToPostReservationOnOtherHospitals =
            "As a hospital, you are not allowed to post reservations on other hospitals";

        public const string PatientCannotCreateVisit =
            "Visits are created by doctors upon visitation, you are not allowed to do that as a patient";

        public const string DoctorNotAllowedToPostVisitOnOtherDoctors =
            "As a doctor, you are not allowed to post visitations on other doctors";

        public const string HospitalNotAllowedToPostVisitationOnOtherHospitals =
            "As a hospital, you are not allowed to post visitations on other hospitals";

        public const string DoctorNotPartOfHospitalForVisitation =
            "The specified doctor is not part of the specified hospital, therefore visitations on his name in that hospital cannot exist";

        public const string PatientCannotModifyVisitation =
            "As a patient, you are not allowed to modify a visitation. Talk to your doctor for wrong data";

        public const string PatientCannotCreateDiagnoses =
            "Diagnoses are created by doctors upon visitation, you are not allowed to do that as a patient";

        public const string DoctorNotAllowedToPostDiagnosisOnOtherDoctors =
            "As a doctor, you are not allowed to post diagnosis on other doctors' patients";

        public const string UnsupportedOperationForRole = "This operation is not supported for your role";
        public const string PatientDoesNotExist = "Such patient does not exist";
        public const string DoctorDoesNotExist = "Such doctor does not exist";
        public const string HospitalDoesNotExist = "Such hospital does not exist";
        public const string ReservationDoesNotExist = "Such reservation does not exist";
        public const string VisitDoesNotExist = "Such visitation does not exist";
        public const string DiagnosisDoesNotExist = "Such diagnosis does not exist";
        public const string PatientWithEgnAlreadyExists = "A patient with the same EGN already exists";
        public const string DoctorWithEgnAlreadyExists = "A doctor with the same EGN already exists";
    }
}