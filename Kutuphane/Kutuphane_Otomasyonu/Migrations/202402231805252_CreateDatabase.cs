namespace Kutuphane_Otomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmanetKitaplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        SayfaSayisi = c.Int(nullable: false),
                        KitapAldigiTarihi = c.DateTime(nullable: false),
                        KitapIadeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitapHaraketleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        YapilanIslem = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitapKayitHaraketleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitapId = c.Int(nullable: false),
                        YapilanIslem = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitaplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitapTuruId = c.Int(nullable: false),
                        BarkodNo = c.String(),
                        KitapAdi = c.String(),
                        YazarAdi = c.String(),
                        YayinEvi = c.String(),
                        SayfaSayisi = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        GuncellenmeTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitapTurleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitapTuru = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UyeHaraketleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                        Aciklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uyelers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdiSoyadi = c.String(),
                        Telefon = c.String(),
                        Adres = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.Uyelers");
            DropTable("dbo.UyeHaraketleris");
            DropTable("dbo.KitapTurleris");
            DropTable("dbo.Kitaplars");
            DropTable("dbo.KitapKayitHaraketleris");
            DropTable("dbo.KitapHaraketleris");
            DropTable("dbo.EmanetKitaplars");

        }
    }
}
