using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApacheLogParser
{
	public class ApacheLogContext : DbContext
	{
		static ApacheLogContext()
		{
			Database.SetInitializer<ApacheLogContext>(new ApacheLogContextInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			////Шаманство для UNIQUE на столбце имени файла
			//modelBuilder.Entity<FileData>()
			//	.Property(fd => fd.FullName).HasColumnAnnotation(IndexAnnotation.AnnotationName,
			//		new IndexAnnotation(
			//		new IndexAttribute("IX_UniqueFileName") { IsUnique = true }));

			//Шаманство для UNIQUE на столбце IP-адреса
			modelBuilder.Entity<Ip>()
				.Property(ip => ip.IpAddr).HasColumnAnnotation(IndexAnnotation.AnnotationName,
					new IndexAnnotation(
					new IndexAttribute("IX_UniqueIp") { IsUnique = true }));
		}

		public DbSet<ApacheLogEntry> LogEntries { get; set; }
		public DbSet<Ip> IpAddresses { get; set; }
		public DbSet<FileData> Files { get; set; }
	}
}
