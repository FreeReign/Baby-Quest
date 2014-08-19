/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using System.Collections;
using Server.Accounting;
using Server.Misc;

namespace Server.Items
{
	public class BabyPowder : Item
	{
		[Constructable]
		public BabyPowder() : this( 1 )
		{
		}

		[Constructable]
		public BabyPowder( int amount ) : base( 0x26B8 )
		{
			Name = "Baby Powder";
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
			Hue = 1153;
		}

		#region Skill Gain
		public const double SkillGainFactor = 1.0 / 3;
		public static readonly TimeSpan SkillGainPeriod = TimeSpan.FromMinutes( 30.0 );//effect of 33% more skill for 30 minutes

		private static Hashtable m_SkillGain = new Hashtable();

		private class SkillGainContext
		{
			public Timer m_Timer;
			public ArrayList m_Mods;
		}

		public override void OnDoubleClick( Mobile mob )
		{
			SkillGainContext context = (SkillGainContext)m_SkillGain[mob];

			if ( context != null )
				return;

			context = new SkillGainContext();
			m_SkillGain[mob] = context;

			ArrayList mods = context.m_Mods = new ArrayList();

			for ( int i = 0; i < mob.Skills.Length; ++i )
			{
				Skill sk = mob.Skills[i];
				double baseValue = sk.Base;
				
				if ( mob.InRange( this.GetWorldLocation(), 2 ) )
				{
					Container pack = mob.Backpack;
					int m_Amount = mob.Backpack.GetAmount( typeof( BabyPowder ) );
					
					if ( pack != null && pack.ConsumeTotal( typeof( BabyPowder ), m_Amount) )
					{	
						if( m_Amount != 1 )
						{
							mob.AddToBackpack( new BabyPowder( m_Amount-1 ));
						}
						
						
						if ( baseValue > 0 )
						{
						SkillMod mod = new DefaultSkillMod( SkillName.Fencing, true, +(baseValue * SkillGainFactor) );
						SkillMod mod1 = new DefaultSkillMod( SkillName.Parry, true, +(baseValue * SkillGainFactor) );
						SkillMod mod2 = new DefaultSkillMod( SkillName.Swords, true, +(baseValue * SkillGainFactor) );
						SkillMod mod3 = new DefaultSkillMod( SkillName.Archery, true, +(baseValue * SkillGainFactor) );
						SkillMod mod4 = new DefaultSkillMod( SkillName.Macing, true, +(baseValue * SkillGainFactor) );
						SkillMod mod5 = new DefaultSkillMod( SkillName.Tactics, true, +(baseValue * SkillGainFactor) );
						SkillMod mod6 = new DefaultSkillMod( SkillName.Wrestling, true, +(baseValue * SkillGainFactor) );

						mods.Add( mod );
						mods.Add( mod1 );
						mods.Add( mod2 );
						mods.Add( mod3 );
						mods.Add( mod4 );
						mods.Add( mod5 );
						mods.Add( mod6 );
						mob.AddSkillMod( mod );
						mob.AddSkillMod( mod1 );
						mob.AddSkillMod( mod2 );
						mob.AddSkillMod( mod3 );
						mob.AddSkillMod( mod4 );
						mob.AddSkillMod( mod5 );
						mob.AddSkillMod( mod6 );
						
						mob.SendMessage("You sprinkle some baby powder on your body and it makes your skin more resistant in combat.");
						}
						else
						{
						mob.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
						}
						}
				}
			}

			context.m_Timer = Timer.DelayCall( SkillGainPeriod, new TimerStateCallback( ClearSkillGain_Callback ), mob );
		}

		private static void ClearSkillGain_Callback( object state )
		{
			ClearSkillGain( (Mobile) state );
		}

		public static void ClearSkillGain( Mobile mob )
		{
			SkillGainContext context = (SkillGainContext)m_SkillGain[mob];

			if ( context == null )
				return;

			m_SkillGain.Remove( mob );

			ArrayList mods = context.m_Mods;

			for ( int i = 0; i < mods.Count; ++i )
				mob.RemoveSkillMod( (SkillMod) mods[i] );

			context.m_Timer.Stop();
		}
		#endregion

		public BabyPowder( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
