using System.Linq;
using AutoMapper;
using PS.Mapping.DTOs;
using PS.Models;
using PS.Persistence;

namespace PS.Mapping.Profiles
{
    /// <inheritdoc />
    public class ApplicationMappingProfile : Profile
    {
        /// <inheritdoc />
        public ApplicationMappingProfile()
        {
            CreateMapForDoctor();
            CreateMapForPatient();
            CreateMapForHospital();
            CreateMapForReservation();
            CreateMapForVisit();
            CreateMapForDiagnosis();
        }

        private void CreateMapForDoctor()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
        }

        private void CreateMapForPatient()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
        }

        private void CreateMapForHospital()
        {
            CreateMap<HospitalDto, Hospital>();
            CreateMap<Hospital, HospitalDto>().ForMember(hospitalDto => hospitalDto.DoctorGuids,
                map => map.MapFrom(hospital =>
                    hospital.HospitalDoctors.Select(hospitalDoctorLink =>
                        hospitalDoctorLink.DoctorId).ToList()));
        }

        private void CreateMapForReservation()
        {
            CreateMap<HistoricalReservation, HistoricalReservationDto>().ForMember(
                    historicalReservationDto => historicalReservationDto.Doctor,
                    map => map.MapFrom(historicalReservation => Mapper.Map<Doctor, DoctorDto>(historicalReservation.Doctor)))
                .ForMember(historicalReservationDto => historicalReservationDto.Hospital,
                    map => map.MapFrom(historicalReservation =>
                        Mapper.Map<Hospital, HospitalDto>(historicalReservation.Hospital)))
                .ForMember(historicalReservationDto => historicalReservationDto.Patient, map =>
                    map.MapFrom(historicalReservation =>
                        Mapper.Map<Patient, PatientDto>(historicalReservation.Patient)));

            CreateMap<HistoricalReservationDto, HistoricalReservation>().ForMember(
                    historicalReservation => historicalReservation.DoctorId,
                    map => map.MapFrom(historicalReservationDto => historicalReservationDto.Doctor.Guid))
                .ForMember(historicalReservation => historicalReservation.HospitalId,
                    map => map.MapFrom(historicalReservationDto =>
                        historicalReservationDto.Hospital.Guid))
                .ForMember(historicalReservation => historicalReservation.PatientId, map =>
                    map.MapFrom(historicalReservationDto => historicalReservationDto.Patient.Guid))
                .ForMember(historicalReservation => historicalReservation.Patient, opts => opts.Ignore())
                .ForMember(historicalReservation => historicalReservation.Doctor, opts => opts.Ignore())
                .ForMember(historicalReservation => historicalReservation.Hospital, opts => opts.Ignore());
        }

        private void CreateMapForVisit()
        {
            CreateMap<HistoricalVisit, HistoricalVisitDto>().ForMember(
                    historicalVisitDto => historicalVisitDto.Doctor,
                    map => map.MapFrom(historicalVisit => Mapper.Map<Doctor, DoctorDto>(historicalVisit.Doctor)))
                .ForMember(historicalVisitDto => historicalVisitDto.Hospital,
                    map => map.MapFrom(historicalVisit =>
                        Mapper.Map<Hospital, HospitalDto>(historicalVisit.Hospital)))
                .ForMember(historicalVisitDto => historicalVisitDto.Patient, map =>
                    map.MapFrom(historicalVisit =>
                        Mapper.Map<Patient, PatientDto>(historicalVisit.Patient)));
            CreateMap<HistoricalVisitDto, HistoricalVisit>().ForMember(
                    historicalVisit => historicalVisit.DoctorId,
                    map => map.MapFrom(historicalVisitDto => historicalVisitDto.Doctor.Guid))
                .ForMember(historicalVisit => historicalVisit.HospitalId,
                    map => map.MapFrom(historicalVisitDto =>
                        historicalVisitDto.Hospital.Guid))
                .ForMember(historicalVisit => historicalVisit.PatientId, map =>
                    map.MapFrom(historicalVisitDto => historicalVisitDto.Patient.Guid))
                .ForMember(historicalVisit => historicalVisit.Patient, opts => opts.Ignore())
                .ForMember(historicalVisit => historicalVisit.Doctor, opts => opts.Ignore())
                .ForMember(historicalVisit => historicalVisit.Hospital, opts => opts.Ignore());
        }

        private void CreateMapForDiagnosis()
        {
            CreateMap<HistoricalDiagnosis, HistoricalDiagnosisDto>().ForMember(
                    historicalDiagnosisDto => historicalDiagnosisDto.Patient,
                    map => map.MapFrom(historicalDiagnosis => Mapper.Map<Patient, PatientDto>(historicalDiagnosis.Patient)))
                .ForMember(historicalDiagnosisDto => historicalDiagnosisDto.Doctor,
                    map => map.MapFrom(historicalDiagnosis => Mapper.Map<Doctor, DoctorDto>(historicalDiagnosis.Doctor)))
                .ForMember(historicalDiagnosisDto => historicalDiagnosisDto.DiagnosisDescription,
                    map => map.MapFrom(historicalDiagnosis => historicalDiagnosis.SicknessDescription));
            CreateMap<HistoricalDiagnosisDto, HistoricalDiagnosis>().ForMember(
                    historicalDiagnosis => historicalDiagnosis.PatientId,
                    map => map.MapFrom(historicalDiagnosisDto => historicalDiagnosisDto.Patient.Guid))
                .ForMember(historicalDiagnosis => historicalDiagnosis.DoctorId,
                    map => map.MapFrom(historicalDiagnosisDto => historicalDiagnosisDto.Doctor.Guid))
                .ForMember(historicalDiagnosis => historicalDiagnosis.Doctor, opts => opts.Ignore())
                .ForMember(historicalDiagnosis => historicalDiagnosis.Patient, opts => opts.Ignore()).ForMember(
                    historicalDiagnosis => historicalDiagnosis.SicknessDescription,
                    map => map.MapFrom(historicalDiagnosisDto => historicalDiagnosisDto.DiagnosisDescription));
        }
    }
}