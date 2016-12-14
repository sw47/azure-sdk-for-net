// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbEltcGw=
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.Resource.Definition;
    using SqlElasticPool.Definition;
    using SqlElasticPool.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlElasticPool and its parent interfaces.
    /// </summary>
    internal partial class SqlElasticPoolImpl :
        IndependentChildResourceImpl<ISqlElasticPool, ISqlServer, ElasticPoolInner, SqlElasticPoolImpl, IHasId, IUpdate>,
        ISqlElasticPool,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlElasticPool, ISqlServer>
    {
        private IElasticPoolsOperations innerCollection;
        private IDatabasesOperations databasesInner;
        private DatabasesImpl databasesImpl;
        private IDictionary<string, SqlDatabaseImpl> databaseCreatableMap;

        ///GENMHASH:C183D7089E5DF699C59758CC103308DF:9A4ADAD649EDB890CDCEB767D8708E33
        public IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> ListActivities()
        {
            var activities = this.innerCollection.ListActivity(this.ResourceGroupName, this.SqlServerName(),
                    this.Name);

            var activitiesToReturn = new List<IElasticPoolActivity>();
            foreach (var elasticPoolActivityInner in activities)
            {
                activitiesToReturn.Add(new ElasticPoolActivityImpl(elasticPoolActivityInner));
            }

            return activitiesToReturn;
        }

        ///GENMHASH:AF85C434312924FAA083308209A3AF10:5BC46D00C0259DC73BA821EECB730B17
        private async Task CreateOrUpdateDatabaseAsync()
        {
            if (this.databaseCreatableMap.Any())
            {
                await this.databasesImpl.Databases.CreateAsync(this.databaseCreatableMap.Values.ToArray());
                this.databaseCreatableMap.Clear();
            }
        }

        internal SqlElasticPoolImpl(string name, ElasticPoolInner innerObject, IElasticPoolsOperations innerCollection, IDatabasesOperations databasesInner, DatabasesImpl databasesImpl)
            : base(name, innerObject)
        {
            this.innerCollection = innerCollection;
            this.databasesInner = databasesInner;
            this.databasesImpl = databasesImpl;
            this.databaseCreatableMap = new Dictionary<string, SqlDatabaseImpl>();
        }

        ///GENMHASH:F018FD6E531156DFCBAA9FAE7F4D8519:F548C4892951BC9F8563B941B288836A
        public int DatabaseDtuMax()
        {
            return this.Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:CE6E5E981686AB8CE8A830CF9AB6387F:D3C554B6F628CA009F2AB5D1A90A12F8
        public SqlElasticPoolImpl WithEdition(string edition)
        {
            this.Inner.Edition = edition;
            return this;
        }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:945958DE33096D51BB9DD38A7F3CDAD0
        public int Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:04B212B505D5C86A62596EEEE457DD66
        public string SqlServerName()
        {
            return this.parentName;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:EA721512D35742AECA1CE1F7CBF2BB99
        protected override async Task<ISqlElasticPool> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var elasticPoolInner = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.SqlServerName(), Name, this.Inner);
            SetInner(elasticPoolInner);

            await CreateOrUpdateDatabaseAsync();
            return this;
        }

        ///GENMHASH:CD775E31F43CBA6304D6EEA9E01682A1:2A3515CB32DF22200CBB032FFC4BCCFC
        public IList<ISqlDatabase> ListDatabases()
        {
            var databases = this.innerCollection.ListDatabases(
                        this.ResourceGroupName,
                        this.SqlServerName(),
                        this.Name);
            return databases.Select((databaseInner) => (ISqlDatabase)new SqlDatabaseImpl(databaseInner.Name, databaseInner, this.databasesInner)).ToList();
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public string Edition()
        {
            return this.Inner.Edition;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:1ACD6B53BB71F7548B6ACD87115C57CE
        public override ISqlElasticPool Refresh()
        {
            this.innerCollection.Get(this.ResourceGroupName, this.SqlServerName(), this.Name);
            return this;
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            return this.Inner.CreationDate.GetValueOrDefault();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:EBCADD6850E9711DA91415429B1577E3
        public void Delete()
        {
            this.innerCollection.Delete(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }

        ///GENMHASH:D7949083DDCDE361387E2A975A1A1DE5:F01D6FF97E40E88626C9C874F2B4B251
        public SqlElasticPoolImpl WithNewDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName,
                (SqlDatabaseImpl)this.databasesImpl.Define(databaseName).WithExistingElasticPool(this.Name).WithoutSourceDatabaseId());
            return this;
        }

        ///GENMHASH:DA730BE4F3BEA4D8DCD1631C079435CB:2D0DE4C2F41ED4D39BD2E654A3511EEE
        public IList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities()
        {
            var databaseActivities = this.innerCollection.ListDatabaseActivity(
                    this.SqlServerName(),
                    this.ResourceGroupName,
                    this.Name);
            return databaseActivities.Select((elasticPoolDatabaseActivityInner) => (IElasticPoolDatabaseActivity)new ElasticPoolDatabaseActivityImpl(elasticPoolDatabaseActivityInner)).ToList();
        }

        ///GENMHASH:5AD4BED8CF2346B6D40F11D14D91854E:DF850590D9C93BFBF3C7222561137EEB
        public int DatabaseDtuMin()
        {
            return this.Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:1C25D7B8D9084176A24655682A78634D:ABBCB4CE203E2AC2B27991A84095239D
        public ISqlDatabase GetDatabase(string databaseName)
        {
            DatabaseInner database = this.innerCollection.GetDatabase(
                this.ResourceGroupName,
                this.SqlServerName(),
                this.Name,
                databaseName);
            return new SqlDatabaseImpl(database.Name, database, this.databasesInner);
        }

        ///GENMHASH:B88CB61BDAE447E93768AB406D02A57B:0FE1382F901F74708CFA53CB4FCDAC21
        public SqlElasticPoolImpl WithExistingDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName, (SqlDatabaseImpl)this.databasesImpl.Get(databaseName).Update().WithExistingElasticPool(this.Name));
            return this;
        }

        ///GENMHASH:C10E7F9E5F3E5F8EEC698AD28741D89A:C6490D8ECDC0B138B8A9D197F5D2C831
        public SqlElasticPoolImpl WithExistingDatabase(ISqlDatabase database)
        {
            this.databaseCreatableMap.Add(database.Name, (SqlDatabaseImpl)database.Update().WithExistingElasticPool(this.Name));
            return this;
        }

        ///GENMHASH:52F9B4107BF3F85A991B429161CF5EB8:41FD2D9003985AE2BA9F4027A8AE05F9
        public SqlElasticPoolImpl WithDatabaseDtuMin(int databaseDtuMin)
        {
            this.Inner.DatabaseDtuMin = databaseDtuMin;
            return this;
        }

        ///GENMHASH:BE89876FF9AA93145223609370F06FD8:FBCF393F261D9724E5F8A4C1DD0CEF0D
        public SqlElasticPoolImpl WithDatabaseDtuMax(int databaseDtuMax)
        {
            this.Inner.DatabaseDtuMax = databaseDtuMax;
            return this;
        }

        ///GENMHASH:FB97B6A01BB44DE1679EAB5070CAB853:22EC24984E8319C6ED4EE03CBB19BAE4
        public int StorageMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:E293D352B4C8ABEA82BF928E8B1ADC36:E89B91984CA129C2BAB11F8710EC7526
        public SqlElasticPoolImpl WithDtu(int dtu)
        {
            this.Inner.Dtu = dtu;
            return this;
        }

        ///GENMHASH:5219D4DB320BF9F9DA49E9B44C0088EE:3721F7B0F159C1617BDBEA9251EA81E6
        public SqlElasticPoolImpl WithStorageCapacity(int storageMB)
        {
            this.Inner.StorageMB = storageMB;
            return this;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public string State()
        {
            return this.Inner.State;
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            return base.WithTags(tags);
        }

        IWithCreate IDefinitionWithTags<IWithCreate>.WithTag(string key, string value)
        {
            return base.WithTag(key, value);
        }
    }
}