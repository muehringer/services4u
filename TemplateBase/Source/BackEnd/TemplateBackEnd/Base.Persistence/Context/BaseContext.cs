using Base.Persistence.Mapping;
using Base.Persistence.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Context
{
    public class BaseContext<T> : DbContext where T : class
    {
        public DbSet<T> DbSet
        {
            get;
            set;
        }

        public BaseContext() : base(ConnectionConfiguration.ConnectionString)
        {
            Database.SetInitializer<BaseContext<T>>(new CreateDatabaseIfNotExists<BaseContext<T>>());

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //* modelBuilder.Configurations.Add(new SampleMapping());
            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos evitando a linha acima com *
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            // Varrendo todos os tipos que são mapeamento 
            // Com ajuda do Reflection criamos as instancias 
            // e adicionamos no Entity Framework
            typesToMapping.ForEach(mapping => {
                dynamic mappingClass = Activator.CreateInstance(mapping);

                modelBuilder.Configurations.Add(mappingClass);
            });

            base.OnModelCreating(modelBuilder);
        }

        public virtual void ChangeObjectState(object model, EntityState state)
        {
            //Aqui trocamos o estado do objeto, 
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter)this)
                          .ObjectContext
                          .ObjectStateManager
                          .ChangeObjectState(model, state);
        }

        //* Devido ao mapeamento na classe OnModelCreating não precisa da linha abaixo
        //public virtual DbSet<Sample> Sample { get; set; }
    }
}
