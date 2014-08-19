/* This quest was made in Honor of Debbie from the DebbaDoo Server and stolen by SphericalSolaris */
using System;
using Server;

namespace Server.Items
{
	public class Baby : Item
	{
		[Constructable]
		public Baby() : base( 0x1AE6 )
		{
			Weight = 2.0;
			Hue = 0xE6;
			Name = "a baby";
			Light = LightType.Empty;
		}

		public override void OnDoubleClick( Mobile from )
		{
			{
				from.PlaySound( 0x8E );

			}
		}

		public Baby( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}


