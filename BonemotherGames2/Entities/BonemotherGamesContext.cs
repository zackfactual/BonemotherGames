using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BonemotherGames2.Entities
{
    public partial class BonemotherGamesContext : DbContext
    {
        public BonemotherGamesContext()
        {
        }

        public BonemotherGamesContext(DbContextOptions<BonemotherGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ability> Ability { get; set; }
        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<AllyLookup> AllyLookup { get; set; }
        public virtual DbSet<AmbassadorLookup> AmbassadorLookup { get; set; }
        public virtual DbSet<Ancestry> Ancestry { get; set; }
        public virtual DbSet<AncestryLanguage> AncestryLanguage { get; set; }
        public virtual DbSet<AncestryRetainerTrait> AncestryRetainerTrait { get; set; }
        public virtual DbSet<AncestryUnitTrait> AncestryUnitTrait { get; set; }
        public virtual DbSet<Armor> Armor { get; set; }
        public virtual DbSet<ArtisanLookup> ArtisanLookup { get; set; }
        public virtual DbSet<CreatureSize> CreatureSize { get; set; }
        public virtual DbSet<FollowerChart> FollowerChart { get; set; }
        public virtual DbSet<FollowerSource> FollowerSource { get; set; }
        public virtual DbSet<FollowerSourceFollowerChart> FollowerSourceFollowerChart { get; set; }
        public virtual DbSet<FollowerType> FollowerType { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<NameAncestry> NameAncestry { get; set; }
        public virtual DbSet<PaladinMountLookup> PaladinMountLookup { get; set; }
        public virtual DbSet<RetainerAction> RetainerAction { get; set; }
        public virtual DbSet<RetainerClass> RetainerClass { get; set; }
        public virtual DbSet<RetainerClassAbility> RetainerClassAbility { get; set; }
        public virtual DbSet<RetainerClassRetainerAction> RetainerClassRetainerAction { get; set; }
        public virtual DbSet<RetainerClassSave> RetainerClassSave { get; set; }
        public virtual DbSet<RetainerClassSkill> RetainerClassSkill { get; set; }
        public virtual DbSet<RetainerTrait> RetainerTrait { get; set; }
        public virtual DbSet<RollableUnit> RollableUnit { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Subancestry> Subancestry { get; set; }
        public virtual DbSet<SubancestryLanguage> SubancestryLanguage { get; set; }
        public virtual DbSet<SubancestryRetainerTrait> SubancestryRetainerTrait { get; set; }
        public virtual DbSet<UnitEquipment> UnitEquipment { get; set; }
        public virtual DbSet<UnitExperience> UnitExperience { get; set; }
        public virtual DbSet<UnitSize> UnitSize { get; set; }
        public virtual DbSet<UnitTrait> UnitTrait { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=BonemotherGames;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>(entity =>
            {
                entity.Property(e => e.AbilityName).HasMaxLength(16);
            });

            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.Property(e => e.ActionTypeName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<AllyLookup>(entity =>
            {
                entity.Property(e => e.AllyLookupName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Ancestry>(entity =>
            {
                entity.Property(e => e.AncestryName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.CreatureSize)
                    .WithMany(p => p.Ancestry)
                    .HasForeignKey(d => d.CreatureSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreatureSizeId");
            });

            modelBuilder.Entity<AncestryLanguage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ancestry_Language");

                entity.HasOne(d => d.Ancestry)
                    .WithMany()
                    .HasForeignKey(d => d.AncestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LanguageAncestryIdMapping");

                entity.HasOne(d => d.Language)
                    .WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryLanguageIdMapping");
            });

            modelBuilder.Entity<AncestryRetainerTrait>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ancestry_RetainerTrait");

                entity.HasOne(d => d.Ancestry)
                    .WithMany()
                    .HasForeignKey(d => d.AncestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryIdRetainerTrait");

                entity.HasOne(d => d.Trait)
                    .WithMany()
                    .HasForeignKey(d => d.TraitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryRetainerTraitId");
            });

            modelBuilder.Entity<AncestryUnitTrait>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ancestry_UnitTrait");

                entity.HasOne(d => d.Ancestry)
                    .WithMany()
                    .HasForeignKey(d => d.AncestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryIdUnitTrait");

                entity.HasOne(d => d.UnitTrait)
                    .WithMany()
                    .HasForeignKey(d => d.UnitTraitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryUnitTraitId");
            });

            modelBuilder.Entity<Armor>(entity =>
            {
                entity.Property(e => e.ArmorWeight)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<ArtisanLookup>(entity =>
            {
                entity.HasKey(e => e.ArtisanLookup1)
                    .HasName("PK__ArtisanL__B1EBC2B91B651C5D");

                entity.Property(e => e.ArtisanLookup1).HasColumnName("ArtisanLookup");

                entity.Property(e => e.Benefit).IsRequired();

                entity.Property(e => e.Shop)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<CreatureSize>(entity =>
            {
                entity.Property(e => e.CreatureSizeName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<FollowerChart>(entity =>
            {
                entity.Property(e => e.FollowerName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.AllyLookup)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.AllyLookupId)
                    .HasConstraintName("FK_FollowerChartAllyLookupId");

                entity.HasOne(d => d.Ancestry)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.AncestryId)
                    .HasConstraintName("FK_FollowerChartAmbassadorAncestry");

                entity.HasOne(d => d.FollowerType)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.FollowerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FollowerTypeId");

                entity.HasOne(d => d.PaladinMountLookup)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.PaladinMountLookupId)
                    .HasConstraintName("FK_FollowerChartPaladinMountLookupId");

                entity.HasOne(d => d.RetainerClass)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.RetainerClassId)
                    .HasConstraintName("FK_FollowerChartRetainerClassId");

                entity.HasOne(d => d.RollableUnit)
                    .WithMany(p => p.FollowerChart)
                    .HasForeignKey(d => d.RollableUnitId)
                    .HasConstraintName("FK_FollowerChartRollableUnitId");
            });

            modelBuilder.Entity<FollowerSource>(entity =>
            {
                entity.HasKey(e => e.LeaderClassId)
                    .HasName("PK__LeaderCl__4903196DB1DA7F0E");

                entity.Property(e => e.LeaderClassName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<FollowerSourceFollowerChart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FollowerSource_FollowerChart");

                entity.HasOne(d => d.FollowerChart)
                    .WithMany()
                    .HasForeignKey(d => d.FollowerChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FollowerChartSource");

                entity.HasOne(d => d.LeaderClass)
                    .WithMany()
                    .HasForeignKey(d => d.LeaderClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FollowerRollerSource");
            });

            modelBuilder.Entity<FollowerType>(entity =>
            {
                entity.Property(e => e.FollowerTypeName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.Property(e => e.NameText)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<NameAncestry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Name_Ancestry");

                entity.HasOne(d => d.Ancestry)
                    .WithMany()
                    .HasForeignKey(d => d.AncestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameAncestryId");

                entity.HasOne(d => d.Name)
                    .WithMany()
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AncestryNameId");

                entity.HasOne(d => d.Subancestry)
                    .WithMany()
                    .HasForeignKey(d => d.SubancestryId)
                    .HasConstraintName("FK_NameSubancestryId");
            });

            modelBuilder.Entity<PaladinMountLookup>(entity =>
            {
                entity.Property(e => e.PaladinMountName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<RetainerAction>(entity =>
            {
                entity.HasKey(e => e.ActionId)
                    .HasName("PK__Retainer__FFE3F4D92168BC3E");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.RetainerAction)
                    .HasForeignKey(d => d.ActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionTypeId");
            });

            modelBuilder.Entity<RetainerClass>(entity =>
            {
                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Armor)
                    .WithMany(p => p.RetainerClass)
                    .HasForeignKey(d => d.ArmorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArmorId");
            });

            modelBuilder.Entity<RetainerClassAbility>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RetainerClass_Ability");

                entity.HasOne(d => d.Ability)
                    .WithMany()
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbilityIdPrimaryAbilityMapping");

                entity.HasOne(d => d.RetainerClass)
                    .WithMany()
                    .HasForeignKey(d => d.RetainerClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetainerClassIdPrimaryAbilityMapping");
            });

            modelBuilder.Entity<RetainerClassRetainerAction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RetainerClass_RetainerAction");

                entity.HasOne(d => d.Action)
                    .WithMany()
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetainerActionIdMapping");

                entity.HasOne(d => d.RetainerClass)
                    .WithMany()
                    .HasForeignKey(d => d.RetainerClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetainerClassIdActionMapping");
            });

            modelBuilder.Entity<RetainerClassSave>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RetainerClass_Save");

                entity.HasOne(d => d.Ability)
                    .WithMany()
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbilityIdSaveMapping");

                entity.HasOne(d => d.RetainerClass)
                    .WithMany()
                    .HasForeignKey(d => d.RetainerClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetainerClassIdSaveMapping");
            });

            modelBuilder.Entity<RetainerClassSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RetainerClass_Skill");

                entity.HasOne(d => d.RetainerClass)
                    .WithMany()
                    .HasForeignKey(d => d.RetainerClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetainerClassIdSkillMapping");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SkillId");
            });

            modelBuilder.Entity<RetainerTrait>(entity =>
            {
                entity.HasKey(e => e.TraitId)
                    .HasName("PK__Retainer__8D615ACF6ADD0A41");

                entity.Property(e => e.TraitDescription).IsRequired();

                entity.Property(e => e.TraitName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<RollableUnit>(entity =>
            {
                entity.HasOne(d => d.UnitEquipment)
                    .WithMany(p => p.RollableUnit)
                    .HasForeignKey(d => d.UnitEquipmentId)
                    .HasConstraintName("FK_UnitEquipment");

                entity.HasOne(d => d.UnitExperience)
                    .WithMany(p => p.RollableUnit)
                    .HasForeignKey(d => d.UnitExperienceId)
                    .HasConstraintName("FK_UnitExperience");

                entity.HasOne(d => d.UnitSize)
                    .WithMany(p => p.RollableUnit)
                    .HasForeignKey(d => d.UnitSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitSize");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.RollableUnit)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitType");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Subancestry>(entity =>
            {
                entity.Property(e => e.SubancestryName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Ancestry)
                    .WithMany(p => p.Subancestry)
                    .HasForeignKey(d => d.AncestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubancestryToAncestryId");
            });

            modelBuilder.Entity<SubancestryLanguage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Subancestry_Language");

                entity.HasOne(d => d.Language)
                    .WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubancestryLanguageId");

                entity.HasOne(d => d.Subancestry)
                    .WithMany()
                    .HasForeignKey(d => d.SubancestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubancestryIdLanguage");
            });

            modelBuilder.Entity<SubancestryRetainerTrait>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Subancestry_RetainerTrait");

                entity.HasOne(d => d.Subancestry)
                    .WithMany()
                    .HasForeignKey(d => d.SubancestryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubancestryIdRetainerTrait");

                entity.HasOne(d => d.Trait)
                    .WithMany()
                    .HasForeignKey(d => d.TraitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubancestryRetainerTraitId");
            });

            modelBuilder.Entity<UnitEquipment>(entity =>
            {
                entity.Property(e => e.UnitEquipmentName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<UnitExperience>(entity =>
            {
                entity.Property(e => e.UnitExperienceName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<UnitSize>(entity =>
            {
                entity.Property(e => e.UnitSizeName)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<UnitTrait>(entity =>
            {
                entity.Property(e => e.TraitName).HasMaxLength(32);
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.Property(e => e.UnitTypeName)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
