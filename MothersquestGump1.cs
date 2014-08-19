/* This quest was made in Honor of Debbie from the DebbaDoo Server */
using System; 
using Server;
using Server.Commands;
using Server.Commands.Generic; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class MothersquestGump1 : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "MothersquestGump1", AccessLevel.GameMaster, new CommandEventHandler( MothersquestGump1_OnCommand ) ); 
      } 

      private static void MothersquestGump1_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new MothersquestGump1( e.Mobile ) ); 
      } 

      public MothersquestGump1( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Debbie's kidnapped baby" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>The mother looks up at you with a very sad look.<BR><BR>While the town of Moonglow was being invaded our homes were looted and destroyed.<BR>In fear for our child's life, my husband and I hid her in a beautiful pink metal chest.<BR>" +
"<BASEFONT COLOR=YELLOW>But to our dismay, while fighting for our own lives, the chest had been stolen by the filthy beasts.<BR> We are now leaving our young infants fate in your hands.<BR>Should you return her to us unharmed, we will gladly reward you well beyond our poor wages can afford.<BR><BR>This is the only information we have gathered to ease your quest for our darling baby.<BR><BR>1. It is in a land far away where men kill men for nothing more then sport.<BR>" +
"<BASEFONT COLOR=YELLOW>2. The fiends have placed the chest amongst their treasure chests, still unaware of the precious cargo within it.<BR>" +
"<BASEFONT COLOR=YELLOW>3. I have heard rumors, their fort is located just outside a town where the name of it alone conjures up thoughts of boats and fishing.<BR><BR>" +
"<BASEFONT COLOR=YELLOW>Please find these villians, slay them, and get my baby back, May God carry you through these hard times." +

						     "</BODY>", false, true);
			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               from.SendMessage( "May god be with you!" );
               break; 
            } 

         }
      }
   }
}
