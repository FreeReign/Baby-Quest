/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a loving mother's corpse" )]
	public class Mother : BaseCreature
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Mother():base(AIType.AI_Melee, FightMode.None, 20, 1, 1.5, 3.0)
		{

			Name = "Debbie";
			Body = 401;
			Female = true;
			SpeechHue = 6;
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
			
			Item PlainDress = new PlainDress();//Hue = 0xE6;
			PlainDress.Hue = 0xE6;
			PlainDress.Movable = false;
			AddItem( PlainDress );
			
			Item Sandals = new Sandals();
			Sandals.Hue = 0xE6;
			Sandals.Movable = false;
			AddItem( Sandals );
			
			Item hair = new Item( 0x203D );
			hair.Hue = 351;
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
			
			Item ring = new GoldRing();
			ring.Name = "Wedding Ring";
			ring.Movable = false;
			AddItem( ring );
			
			}
		

		public Mother( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
				base.GetContextMenuEntries( from, list ); 
				list.Add( new MotherEntry( from, this ) ); 
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

		public class MotherEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public MotherEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( MothersquestGump1 ) ) )
					{
						mobile.SendGump( new MothersquestGump1( mobile ));
						
					} 
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is Baby)
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This in not my baby... Please oh please rescue my baby!", mobile.NetState );
         				return false;
         			}
         			
         			mobile.SendMessage("Please give her to my husband, as he can protect our baby best.");
         			dropped.Delete();
         			mobile.AddToBackpack( new Baby() );
					return true;
         		}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "This in not my baby... Please oh please rescue my baby!", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
