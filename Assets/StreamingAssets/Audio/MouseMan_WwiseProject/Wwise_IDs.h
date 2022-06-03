/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID CAT_DEATH1 = 3185863801U;
        static const AkUniqueID CAT_DEATH2 = 3185863802U;
        static const AkUniqueID CAT_DEATH3 = 3185863803U;
        static const AkUniqueID CAT_PURR1 = 3636054496U;
        static const AkUniqueID CAT_STEP = 1726920360U;
        static const AkUniqueID COMBATMUSIC = 3733692670U;
        static const AkUniqueID FIGHT_MUSIC = 1929840817U;
        static const AkUniqueID FORCE = 4240233774U;
        static const AkUniqueID GAME_START = 733168346U;
        static const AkUniqueID MENU_HOVER = 309439191U;
        static const AkUniqueID MENU_SELECT = 4203375351U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID MUSIC_OFF = 2899509660U;
        static const AkUniqueID MUSIC_ON = 2795543126U;
        static const AkUniqueID PC_DASH = 1271964801U;
        static const AkUniqueID PC_FIRE = 2049729833U;
        static const AkUniqueID SIREN = 734002816U;
        static const AkUniqueID SIREN2 = 1597875122U;
        static const AkUniqueID SQUEAK1 = 4183355984U;
        static const AkUniqueID SQUEAK2 = 4183355987U;
        static const AkUniqueID SQUEAK3 = 4183355986U;
        static const AkUniqueID STEP1 = 1718617340U;
        static const AkUniqueID STEP2 = 1718617343U;
        static const AkUniqueID STEPS = 1718617278U;
        static const AkUniqueID STOP = 788884573U;
        static const AkUniqueID STOPRETRY = 3023010813U;
        static const AkUniqueID TESTFIRE = 1788912989U;
        static const AkUniqueID TURRET_FIRE = 2132750258U;
        static const AkUniqueID WALL_DESTROY = 2274397818U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace FIGHTMUSIC
        {
            static const AkUniqueID GROUP = 3890691062U;

            namespace STATE
            {
                static const AkUniqueID FIGHTING_MUSIC = 4264741179U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace FIGHTMUSIC

        namespace MENU_MUSIC
        {
            static const AkUniqueID GROUP = 4055567060U;

            namespace STATE
            {
                static const AkUniqueID FIGHTMUSIC = 3890691062U;
                static const AkUniqueID GAMESTART = 4058101365U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MENU_MUSIC

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID MASTERVOLUME = 2918011349U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID ENVIROMENTAL = 3922907557U;
        static const AkUniqueID FORCER = 188978968U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
