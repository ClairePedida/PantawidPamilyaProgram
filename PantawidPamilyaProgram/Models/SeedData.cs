using Microsoft.EntityFrameworkCore;
using PantawidPamilyaProgram.Data;

namespace PantawidPamilyaProgram.Models

{
    public static class SeedData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new PantawidPamilyaProgramContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PantawidPamilyaProgramContext>>()))
            {
                if (context == null || context.Pppp == null)
                {
                    throw new ArgumentNullException("Null PantawidPamilyaProgramContext");
                }
                if (context.Pppp.Any())
                    {
                    return;
                }
                context.Pppp.AddRange(
                    new Pppp
                    {
                        Name ="CLaire Pedida",
                        Gender ="Female",
                        Address = "Brgy Tayamaan Mamburao,Occidental Mindoro ",
                        Benificiaries = 10,
                    },
                     new Pppp
                     {
                         Name = "Simplicio Manaloto",
                         Gender = "Male",
                         Address = "Brgy Payompon Mamburao,Occidental Mindoro ",
                         Benificiaries = 5,
                     },
                      new Pppp
                      {
                          Name = "Paulene Eustaqio",
                          Gender = "Female",
                          Address = "Brgy 8 Mamburao,Occidental Mindoro ",
                          Benificiaries = 54,
                      },
                       new Pppp
                       {
                           Name = "Maribong Iza",
                           Gender = "Female",
                           Address = "Brgy Armado Abra,Occidental Mindoro ",
                           Benificiaries = 10,
                       },
                        new Pppp
                        {
                            Name = "Glenda Catibog",
                            Gender = "Female",
                            Address = "Brgy Casoy Mamburao,Occidental Mindoro ",
                            Benificiaries = 3,
                        },
                         new Pppp
                         {
                             Name = "Templonuevo Randel",
                             Gender = "Male",
                             Address = "Brgy kurtinganan Sta. Cruz,Occidental Mindoro ",
                             Benificiaries = 3,
                         }

                    );
                context.SaveChanges();
            }
        }
    }

    }

