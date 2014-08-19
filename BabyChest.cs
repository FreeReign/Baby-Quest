/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
/*----------------*/
/*--- Scripted ---*/
/*--- By: JBob ---*/
/*----------------*/
//I scripted this to make spawning the baby easier.
//Double click the chest and the baby is put in the players backpack and the chest deletes
using System;

namespace Server.Items
{
    [FlipableAttribute(0xE43, 0xE42)] 
    public class BabyChest : BaseContainer 
    {
        [Constructable] 
        public BabyChest() : base(0xE43)
        { 
			Name = "Babies Chest";
			Hue = 0xE6;
			Movable = false;
			
			this.DropItem(new Baby());
        }

        public BabyChest(Serial serial) : base(serial)
        { 
        }

        public override void Serialize(GenericWriter writer) 
        { 
            base.Serialize(writer); 

            writer.Write((int)0); // version 
        }

        public override void Deserialize(GenericReader reader) 
        { 
            base.Deserialize(reader); 

            int version = reader.ReadInt(); 
        }
		
		public override void OnDoubleClick( Mobile from )
		{
			Baby baby = (Baby)FindItemByType( typeof(Baby) );
			
			if( baby != null )
			{
				from.SendMessage("You found the baby!");
				from.AddToBackpack(new Baby());
				this.Delete();
			}
			base.OnDoubleClick( from );
		}
    }
}
