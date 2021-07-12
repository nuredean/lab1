using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any() && !context.Vaccines.Any()
             && !context.Chronic_Diseases.Any() && !context.Allergies.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser { DisplayName="Test", UserName="test", Email="test@test.com" },
                    new AppUser { DisplayName="Test2", UserName="test2", Email="test2@test.com" },
                    new AppUser { DisplayName="Test3", UserName="test3", Email="test3@test.com" },
                    new AppUser { DisplayName="doki", UserName="doki", Email="doki@qkuk.rks" },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                var vaccines = new List<Vaccine>
                {
                    new Vaccine
                    {
                        Name = "Pfizer", 
                        Efficacy = "mbi 91.3%",
                        Creator = "BioNTech",
                        Type = "mRNA",
                        Patients = new List<PatientVaccine> {
                            new PatientVaccine {
                                AppUser = users[1]
                            },
                            new PatientVaccine {
                                AppUser = users[3]
                            }
                        }
                    },
                    new Vaccine
                    {
                        Name = "AstraZeneca", 
                        Efficacy = "mbi 81.3%",
                        Creator = "Oxford",
                        Type = "Viral vector" 
                    },
                    new Vaccine
                    {
                        Name = "Moderna", 
                        Efficacy = "mbi 94.1%",
                        Creator = "Moderna, NIAID",
                        Type = "mRNA",
                        Patients = new List<PatientVaccine> {
                            new PatientVaccine {
                                AppUser = users[1]
                            }
                        }
                    }
                };

                await context.Vaccines.AddRangeAsync(vaccines);


                var chronicDiseases = new List<Chronic_Disease>
                {
                    new Chronic_Disease
                    {
                        Name = "Kancer",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[1]
                            },
                            new PatientChronicDisease {
                                AppUser = users[3]
                            }
                        }
                    },
                    new Chronic_Disease
                    {
                        Name = "Semundje te zemres",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[1]
                            }
                    }
                    },
                    new Chronic_Disease
                    {
                        Name = "Hipertension",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[2]
                            }
                        }
                    },
                    new Chronic_Disease
                    {
                        Name = "Diabet",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[3]
                            }
                        }
                    },
                    new Chronic_Disease
                    {
                        Name = "Semundje te mushkrive",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[2]
                            }
                        }
                    },
                    new Chronic_Disease
                    {
                        Name = "Semundje autoimune",
                        Patients = new List<PatientChronicDisease> {
                            new PatientChronicDisease {
                                AppUser = users[3]
                            }
                        }
                    },
                    new Chronic_Disease
                    {
                        Name = "HIV-AIDS"
                    },
                };

                await context.Chronic_Diseases.AddRangeAsync(chronicDiseases);

            
                var allergies = new List<Allergy>
                {
                    new Allergy
                    {
                        Type = "Alegji ne ushqim",
                        Causes = "Shkaqet jane kur trupi juaj formon antitrupa kunder ndonje ushqimi te veqant",
                         Patients = new List<PatientAllergy> {
                            new PatientAllergy {
                                AppUser = users[1]
                            }
                         }
                    },
                    new Allergy
                    {
                        Type = "Alergji ne polen",
                        Causes = "Shkaqet jane polenet e ndryshme ne natyre",
                        Patients = new List<PatientAllergy> {
                            new PatientAllergy {
                                AppUser = users[1]
                            },
                            new PatientAllergy {
                                AppUser = users[2]
                            },
                            new PatientAllergy {
                                AppUser = users[3]
                            }
                         }
                    },
                    new Allergy
                    {
                        Type = "Alegji ne kafshe",
                        Causes = "Shkaqet jane proteinat ne lekuren e kafsheve",
                        Patients = new List<PatientAllergy> {
                            new PatientAllergy {
                                AppUser = users[2]
                            }
                         }
                    }
                };
                await context.Allergies.AddRangeAsync(allergies);

            }

            if (!context.Patients.Any())
            {
                var patients = new List<Patient>
                {
                    new Patient
                    {
                        Full_Name="Qendresa Berisha",
                        Birthday = DateTime.Now.AddMonths(-2),
                        Gender = "Female",
                        Phone_Number = 049343431,
                        Email = "email@gmail.com",
                        Address = "Prishtine"
                    },
                    new Patient
                    {
                        Full_Name="Filan Fisteku",
                        Birthday = DateTime.Now.AddMonths(-2),
                        Gender = "Female",
                        Phone_Number = 049455431,
                        Email = "email@gmail.com",
                        Address = "Prishtine"
                    },
                    new Patient
                    {
                        Full_Name="Shembull3",
                        Birthday =DateTime.Now.AddMonths(-2) ,
                        Gender = "Male",
                        Phone_Number = 049123456,
                        Email = "email@gmail.com",
                        Address = "Prishtine"
                    },
                };

                await context.Patients.AddRangeAsync(patients);
            }

            if (!context.Patients.Any())
            {
                var tests = new List<Test>
                {
                    new Test
                    {
                        PatientId = 2,
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Test 2 months ago",
                        HospitalId = 1,
                        VaccineId = 2,
                        Variation = "B.1.1.7"
                    },
                    new Test
                    {
                        PatientId = 2,
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Test 2 months ago",
                        HospitalId = 1,
                        VaccineId = 3,
                        Variation = "B.1.351"
                    },
                    new Test
                    {
                        PatientId = 2,
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Test 2 months ago",
                        HospitalId = 1,
                        VaccineId = 3,
                        Variation = "P.1"
                    },
                };

                await context.Tests.AddRangeAsync(tests);
            }

            if (!context.Countries.Any())
            {
                var countries = new List<Country>
                {
                    new Country {
                        Id = 1,
                        Name = "Australia",
                        Deaths = 9000000,
                        Infections = 322414123,
                        Vaccinated = 2414123,
                        Recoveries = 3418890,
                    },
                    new Country {
                        Id = 2,
                        Name = "Albania",
                        Deaths = 2800,
                        Infections = 303123,
                        Vaccinated = 314123,
                        Recoveries = 48890,
                    }
                };

                await context.Countries.AddRangeAsync(countries);
            }

            if (!context.Variations.Any())
            {
                var varitatons = new List<Variation>
                {
                    new Variation
                    {
                        Name = "SARS COV-19"
                    },
                    new Variation
                    {
                        Name = "United Kingdom: B.1.1.7"
                    },
                    new Variation
                    {
                        Name = "South Africa: B.1.351"
                    },
                    new Variation
                    {
                        Name = "United States: P.1"
                    },
                    new Variation
                    {
                        Name = "California: B.1.427"
                    },
                    new Variation
                    {
                        Name = "California: B.1.429"
                    }
                };

                await context.Variations.AddRangeAsync(varitatons);
            }

            if (!context.Vaccines.Any())
            {
              
            }

            if (!context.Rezults.Any())
            {
                var testResults = new List<Rezult>
                {
                    new Rezult
                    {
                        Result = "Pozitiv"
                    },
                    new Rezult
                    {
                        Result = "Negativ"
                    }
                };

                await context.Rezults.AddRangeAsync(testResults);
            }

            if (!context.Private_Centers.Any())
            {
                var privateCenters = new List<Private_Center>
                {
                    new Private_Center
                    {
                        Name="Olive Lab",
                        Location="Prishtine"
                    },
                    new Private_Center
                    {
                        Name = "Avicena",
                        Location = "Prishtine"
                    },
                    new Private_Center
                    {
                        Name = "UBT",
                        Location = "Lipjan"
                    },
                    new Private_Center
                    {
                        Name = "Elita Lab",
                        Location = "Prishtine"
                    },
                    new Private_Center
                    {
                        Name = "Medina",
                        Location = "Ferizaj"
                    },
                };

                await context.Private_Centers.AddRangeAsync(privateCenters);
            }

            if (!context.Public_Centers.Any())
            {
                var publicCenters = new List<Public_Center>
                {
                    new Public_Center
                    {
                        Name = "IKSHPK",
                        Location = "Prishtine"
                    },
                    new Public_Center
                    {
                        Name = "QMF-Kalabria",
                        Location = "Prishtine"
                    },
                    new Public_Center
                    {
                        Name = "QMF-Prizren",
                        Location = "Prizren"
                    },
                    new Public_Center
                    {
                        Name = "QMF-Peje",
                        Location = "Peje"
                    },
                };

                await context.Public_Centers.AddRangeAsync(publicCenters);
            }

            if (!context.Drugs.Any())
            {
                var drugs = new List<Drug>
                {
                    new Drug
                    {
                        Name="Sintrom",
                        SideEffects = "Blood Thinning",
                        Type = "Blood Thinner",
                        Description = "Twice a day",
                    },
                };

                await context.Drugs.AddRangeAsync(drugs);
            }
          
            if (!context.Treatments.Any())
            {
                var treatments = new List<Treatment>
                {
                    new Treatment
                    {
                        Description="Yada yada yada",
                        Patient ="UK",
                        Date = DateTime.Now.AddMonths(-2),
                        Doctor = "Twice a day",
                    },
                };

                await context.Treatments.AddRangeAsync(treatments);
            }

            if (!context.VaccineApplications.Any())
            {
                var vaccineApplication = new List<VaccineApplication>
                {
                    new VaccineApplication
                    {
                        Type = "Pfizer",
                        Date = DateTime.Now.AddMonths(-2),
                        Email = "test@test.com",
                        Location = "Prishtine"
                    },
                    new VaccineApplication
                    {
                        Type = "Moderna",
                        Date = DateTime.Now.AddMonths(-2),
                        Email = "test1@test.com",
                        Location = "Prishtine"
                    },
                    new VaccineApplication
                    {
                        Type = "AstraZeneca",
                        Date = DateTime.Now.AddMonths(-2),
                        Email = "test2@test.com",
                        Location = "Prishtine"

                    }
                };
                await context.VaccineApplications.AddRangeAsync(vaccineApplication);

            }

            await context.SaveChangesAsync();
        }
    }
}