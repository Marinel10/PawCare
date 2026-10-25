namespace PawCare.GCommon.Constants
{
    public static class ValidationConstants
    {

        public static class Pet
        {
            public const int NameMin = 2;
            public const int NameMax= 100;
            public const int PetImageUrlMax = 2047;
            public const string BirthDateColumnType = "smalldatetime";


        }
        public static class Species
        {
            public const int NameMin = 2;
            public const int NameMax = 100;
        }
        public static class Breed
        {
            public const int NameMin = 2;
            public const int NameMax = 100;
        }
        public static class Appointment
        {
            public const int ReasonMax = 500;
            public const string AppointmentDateColumnType = "smalldatetime";
        }

        
        public static class Procedure
        {
            public const int NameMin = 2;
            public const int NameMax = 100;

            public const int DescriptionMax = 1000;
        }

        public static class MedicalRecord
        {
            public const int DiagnosisMin = 10;
            public const int DiagnosisMax = 1000;
            public const int TreatmentMax = 2000;
            public const int NotesMax = 3000;

            public const string MedicalRecordDateColumnType = "smalldatetime";
        }
    }
}
