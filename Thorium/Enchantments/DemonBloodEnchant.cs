using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.DemonBlood;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Consumable;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DemonBloodEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Blood Enchantment");
            Tooltip.SetDefault(
@"'Infused with Corrupt Blood'
Dealing damage will grant you a 'Blood Charge'
At maximum charges, your next attack will deal 2x damage and heal you for 20% of the damage dealt
Consecutive attacks against enemies might drop flesh, which grants bonus life and damage
Effects of Vampire Gland, Demon Blood Badge, and Vile Flail-Core");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔血魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'注满了腐化之血'
攻击提供'蓄血'Buff
充能完毕时, 你的下一次攻击会造成双倍伤害, 并将伤害的20%转化为治疗
连续攻击敌人时概率掉落肉, 拾取肉会获得额外生命并增加伤害
拥有吸血鬼试剂, 魔血徽章和邪恶链锤核心的效果
拥有血魔音箱和黄色播放器的效果
召唤宠物泡泡虫");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //demon blood effect
            modPlayer.DemonBloodEnchant = true;
            //vile core
            thoriumPlayer.accVileCore = true;
            //flesh set bonus
            thoriumPlayer.Symbiotic = true;
            //vampire gland
            thoriumPlayer.vampireGland = true;
            modPlayer.FleshEnchant = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DemonBloodHelmet>());
            recipe.AddIngredient(ModContent.ItemType<DemonBloodBreastPlate>());
            recipe.AddIngredient(ModContent.ItemType<DemonBloodGreaves>());
            recipe.AddIngredient(ModContent.ItemType<FleshEnchant>());
            recipe.AddIngredient(ModContent.ItemType<VileCore>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
