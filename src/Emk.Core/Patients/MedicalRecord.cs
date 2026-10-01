namespace Emk.Core.Patients;

/// <summary>Запись медицинской карты пациента.</summary>
public record MedicalRecord(int Id, int PatientId, int DepartmentId, string DiagnosisCode, DateTime CreatedAt);
