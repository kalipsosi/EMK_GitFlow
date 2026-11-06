using Emk.Core.Patients;

namespace Emk.Core.Security;

public enum StaffRole { Doctor, Nurse, Registrar, ChiefPhysician }

public record StaffMember(int Id, StaffRole Role, int DepartmentId);

/// <summary>Кто может открыть медицинскую запись пациента.</summary>
public static class MedicalRecordAccessPolicy
{
    // Исправление: раньше регистратор получал доступ к диагнозам,
    // а врач видел записи всех отделений
    public static bool CanRead(StaffMember staff, MedicalRecord record) => staff.Role switch
    {
        StaffRole.ChiefPhysician => true,
        StaffRole.Doctor or StaffRole.Nurse => staff.DepartmentId == record.DepartmentId,
        _ => false
    };
}
