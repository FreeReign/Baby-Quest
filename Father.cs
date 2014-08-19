/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
using System;
using System.Collections;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;

namespace Server.Mobiles
{
	[CorpseName( "a dedicated father's corpse" )]
	public class father : BaseCreature
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public father():base(AIType.AI_Melee, FightMode.None, 20, 1, 1.5, 3.0)
		{

			Name = "Gary";
			Body = 400;
			SpeechHue = 9;
			CantWalk = true;
			Hue = 46;
			Blessed = true;

			SetStr( 1025, 1250 );
			SetDex( 120, 125 );
			SetInt( 1800, 1935 );
			SetHits( 5000, 5550 );

			SetSkill( SkillName.MagicResist, 205.0, 220.0 );
			SetSkill( SkillName.Focus, 216.0, 230.0);
			SetSkill( SkillName.Magery, 219.0, 225.0 ); 
			SetSkill( SkillName.Meditation, 212.0, 215.0 ); 

			VirtualArmor = 44; 

			Container pack = new Backpack();
			pack.Movable = false;
			AddItem( pack );
			
			Item Boots = new Boots();
			Boots.Hue = 351;
			Boots.Name = "Work Boots";
			Boots.Movable = false;
			AddItem( Boots );
			
			Item LongPants = new LongPants();
			LongPants.Hue = 1282;
      	    LongPants.Name = "Wrangler Jeans";
			LongPants.Movable = false;
			AddItem( LongPants );
			
			Item FancyShirt = new FancyShirt();
			FancyShirt.Hue = 1321;
      	    FancyShirt.Name = "Flannel Button-Up Shirt";
			FancyShirt.Movable = false;
			AddItem( FancyShirt );
			
			Item hair = new Item( 0x203B );
			hair.Hue = 1836;
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
			
			Item ring = new GoldRing();
			ring.Name = "Wedding Ring";
			ring.Movable = false;
			AddItem( ring );
			
			}
		

		public father( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			Account acct=(Account)from.Account;
			bool BabyRecieved = Convert.ToBoolean( acct.GetTag("BabyRecieved") );

			if ( mobile != null)
			{
				if( dropped is Baby)
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This in not my baby! Are you really that cruel to mess with a grieving father?", mobile.NetState );
         				return false;
         			}
         			
         			if ( !BabyRecieved ) //added account tag check
					{ 
         				mobile.SendMessage("I honor your bravery, here are some things my wife promised you.");
         			 	mobile.AddToBackpack( new BabySash() );
         			 	mobile.AddToBackpack( new Gold( 2500 ) );
						mobile.AddToBackpack( new BabyPowder(2) );
         			 	acct.SetTag( "BabyRecieved", "true" );

         			 	dropped.Delete();
         			}
         			else //what to do if account has already been tagged
         			{
         				mobile.SendMessage("You are so kind to have taken the time to find the other missing children, here is some gold for your troubles.");
         				mobile.AddToBackpack( new Gold( 1500 ) );
         				mobile.AddToBackpack( new BabyPowder(1) );
         				dropped.Delete();
         			}
         		}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This in not my baby! Are you really that cruel to mess with a grieving father?", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
