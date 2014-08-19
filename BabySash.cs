/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
using System; 
using Server.Network; 
using Server.Items; 
using Server.Accounting;
using Server.Misc;

namespace Server.Items 
{ 
	[FlipableAttribute( 0x1541, 0x1542 )]
public class BabySash : BaseMiddleTorso 
{
	public StatMod m_StatMod0; 
   	public StatMod m_StatMod1; 
  	public StatMod m_StatMod2;
      
		[Constructable] 
		public BabySash() : this( 0 ) 
		{	
		}
		[Constructable] 
		public BabySash( int hue ) : base( 0x1541, hue ) 
		{ 
			Weight = 1.0; 
			Name = "Sash of a little baby"; 
			Hue = 0xE6;
			LootType = LootType.Blessed;
		}
		
		public BabySash( Serial serial ) : base( serial )
		{ 
		}
		
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); // version
		} 

      public override void Deserialize(GenericReader reader) 
      { 
         base.Deserialize( reader ); 
         int version = reader.ReadInt();
      	
      	if ( Parent is Mobile ) 
         {  
            m_StatMod0 = new StatMod( StatType.Str, "Baby Strength", 5, TimeSpan.Zero ); 
            ((Mobile)Parent).AddStatMod( m_StatMod0 ); 
            m_StatMod1 = new StatMod( StatType.Dex, "Baby Stamina", 5, TimeSpan.Zero ); 
            ((Mobile)Parent).AddStatMod( m_StatMod1 );
            m_StatMod2 = new StatMod( StatType.Int, "Baby Brains", 5, TimeSpan.Zero ); 
            ((Mobile)Parent).AddStatMod( m_StatMod2 );
         }
      }
      
      public override bool OnEquip( Mobile from ) 
      { 
         m_StatMod0 = new StatMod( StatType.Str, "Baby Strength", 5, TimeSpan.Zero ); 
         from.AddStatMod( m_StatMod0 ); 
          m_StatMod1 = new StatMod( StatType.Dex, "Baby Stamina", 5, TimeSpan.Zero ); 
         from.AddStatMod( m_StatMod1 ); 
          m_StatMod2 = new StatMod( StatType.Int, "Baby Brains", 5, TimeSpan.Zero ); 
         from.AddStatMod( m_StatMod2 ); 

         return true;  
      }
      
      public override void OnRemoved( object parent ) 
      { 
         if ( parent is Mobile ) 
         { 
            ((Mobile)parent).RemoveStatMod("Baby Power"); 
            ((Mobile)parent).Hits = ((Mobile)parent).HitsMax; 
         } 
      }
      
      public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		} 
   }    
}
