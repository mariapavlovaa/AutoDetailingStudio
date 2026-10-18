using AutoDetailingStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingStudio.Data.Configuration;

public class AppointmentConfiguration:IEntityTypeConfiguration<Appointment>
{
    
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        
    }
}