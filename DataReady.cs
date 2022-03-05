using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FriendSourceFlags {
    }

    public class GuildFolder {
        public object name { get; set; }
        public long? id { get; set; }
        public List<string> guild_ids { get; set; }
        public object color { get; set; }
    }

    public class UserSettings {
        public bool inline_attachment_media { get; set; }
        public bool show_current_game { get; set; }
        public FriendSourceFlags friend_source_flags { get; set; }
        public bool view_nsfw_guilds { get; set; }
        public bool enable_tts_command { get; set; }
        public bool render_reactions { get; set; }
        public bool gif_auto_play { get; set; }
        public bool stream_notifications_enabled { get; set; }
        public bool animate_emoji { get; set; }
        public int afk_timeout { get; set; }
        public bool detect_platform_accounts { get; set; }
        public string status { get; set; }
        public int explicit_content_filter { get; set; }
        public object custom_status { get; set; }
        public bool default_guilds_restricted { get; set; }
        public string theme { get; set; }
        public bool allow_accessibility_detection { get; set; }
        public string locale { get; set; }
        public bool native_phone_integration_enabled { get; set; }
        public List<string> guild_positions { get; set; }
        public int timezone_offset { get; set; }
        public int friend_discovery_flags { get; set; }
        public bool contact_sync_enabled { get; set; }
        public bool disable_games_tab { get; set; }
        public List<GuildFolder> guild_folders { get; set; }
        public bool inline_embed_media { get; set; }
        public bool developer_mode { get; set; }
        public bool render_embeds { get; set; }
        public int animate_stickers { get; set; }
        public bool message_display_compact { get; set; }
        public bool convert_emoticons { get; set; }
        public bool passwordless { get; set; }
        public List<object> restricted_guilds { get; set; }
    }

    public class MuteConfig {
        public int selected_time_window { get; set; }
        public object end_time { get; set; }
    }

    public class ChannelOverride {
        public bool muted { get; set; }
        public MuteConfig mute_config { get; set; }
        public int message_notifications { get; set; }
        public bool collapsed { get; set; }
        public string channel_id { get; set; }
    }

    public class UserGuildSetting {
        public int version { get; set; }
        public bool suppress_roles { get; set; }
        public bool suppress_everyone { get; set; }
        public bool muted { get; set; }
        public bool mute_scheduled_events { get; set; }
        public MuteConfig mute_config { get; set; }
        public bool mobile_push { get; set; }
        public int message_notifications { get; set; }
        public bool hide_muted_channels { get; set; }
        public string guild_id { get; set; }
        public List<ChannelOverride> channel_overrides { get; set; }
    }

    public class User {
        public bool verified { get; set; }
        public string username { get; set; }
        public int purchased_flags { get; set; }
        public int public_flags { get; set; }
        public bool premium { get; set; }
        public string phone { get; set; }
        public bool nsfw_allowed { get; set; }
        public bool mobile { get; set; }
        public bool mfa_enabled { get; set; }
        public string id { get; set; }
        public int flags { get; set; }
        public string email { get; set; }
        public string discriminator { get; set; }
        public bool desktop { get; set; }
        public string bio { get; set; }
        public object banner_color { get; set; }
        public object banner { get; set; }
        public string avatar { get; set; }
        public object accent_color { get; set; }
        public bool? bot { get; set; }
    }

    public class ClientInfo {
        public int version { get; set; }
        public string os { get; set; }
        public string client { get; set; }
    }

    public class Session {
        public string status { get; set; }
        public string session_id { get; set; }
        public ClientInfo client_info { get; set; }
        public List<object> activities { get; set; }
    }

    public class Relationship {
        public User user { get; set; }
        public int type { get; set; }
        public object nickname { get; set; }
        public string id { get; set; }
    }

    public class ReadState {
        public int mention_count { get; set; }
        public DateTime last_pin_timestamp { get; set; }
        public string last_message_id { get; set; }
        public string id { get; set; }
    }

    public class Recipient {
        public string username { get; set; }
        public int public_flags { get; set; }
        public string id { get; set; }
        public string discriminator { get; set; }
        public string avatar { get; set; }
    }

    public class PrivateChannel {
        public int type { get; set; }
        public List<Recipient> recipients { get; set; }
        public DateTime last_pin_timestamp { get; set; }
        public string last_message_id { get; set; }
        public string id { get; set; }
    }

    public class ClientStatus {
        public string desktop { get; set; }
        public string mobile { get; set; }
    }

    public class Emoji {
        public string name { get; set; }
        public string id { get; set; }
        public bool animated { get; set; }
    }

    public class Timestamps {
        public object start { get; set; }
    }

    public class Activity {
        public int type { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public Emoji emoji { get; set; }
        public object created_at { get; set; }
        public Timestamps timestamps { get; set; }
        public string application_id { get; set; }
    }

    public class Presence {
        public User user { get; set; }
        public string status { get; set; }
        public object last_modified { get; set; }
        public ClientStatus client_status { get; set; }
        public List<Activity> activities { get; set; }
    }

    public class Notes {
        public object _297439477272412161 { get; set; }
        public string _296345532790603776 { get; set; }
        public string _255277450668277760 { get; set; }
        public string _217699041780170752 { get; set; }
        public string _164315362035236864 { get; set; }
    }

    public class VoiceState {
        public string user_id { get; set; }
        public bool suppress { get; set; }
        public string session_id { get; set; }
        public bool self_video { get; set; }
        public bool self_mute { get; set; }
        public bool self_deaf { get; set; }
        public object request_to_speak_timestamp { get; set; }
        public bool mute { get; set; }
        public bool deaf { get; set; }
        public string channel_id { get; set; }
        public bool? self_stream { get; set; }
    }

    public class PermissionOverwrite {
        public int type { get; set; }
        public string id { get; set; }
        public string deny { get; set; }
        public string allow { get; set; }
    }

    public class Channelss {
        public int type { get; set; }
        public string topic { get; set; }
        public int rate_limit_per_user { get; set; }
        public int position { get; set; }
        public List<PermissionOverwrite> permission_overwrites { get; set; }
        public string parent_id { get; set; }
        public string name { get; set; }
        public DateTime last_pin_timestamp { get; set; }
        public string last_message_id { get; set; }
        public string id { get; set; }
        public bool? nsfw { get; set; }
        public int? user_limit { get; set; }
        public string rtc_region { get; set; }
        public int? bitrate { get; set; }
        public int? default_auto_archive_duration { get; set; }
        public int? video_quality_mode { get; set; }
        public bool omitted { get; set; }
        public string hash { get; set; }
    }

    public class Sticker {
        public int type { get; set; }
        public string tags { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string guild_id { get; set; }
        public int format_type { get; set; }
        public string description { get; set; }
        public bool available { get; set; }
        public string asset { get; set; }
    }

    public class ApplicationCommandCounts {
        public int _3 { get; set; }
        public int _2 { get; set; }
        public int _1 { get; set; }
    }

    public class Tags {
        public string bot_id { get; set; }
        public object premium_subscriber { get; set; }
        public string integration_id { get; set; }
    }

    public class Roless {
        public string unicode_emoji { get; set; }
        public int position { get; set; }
        public string permissions { get; set; }
        public string name { get; set; }
        public bool mentionable { get; set; }
        public bool managed { get; set; }
        public string id { get; set; }
        public string icon { get; set; }
        public bool hoist { get; set; }
        public int color { get; set; }
        public Tags tags { get; set; }
        public bool omitted { get; set; }
        public string hash { get; set; }
    }

    public class Metadata {
        public bool omitted { get; set; }
        public string hash { get; set; }
    }

    public class GuildHashes {
        public int version { get; set; }
        public Roless roles { get; set; }
        public Metadata metadata { get; set; }
        public Channelss channels { get; set; }
    }

    public class Emoji2 {
        public List<string> roles { get; set; }
        public bool require_colons { get; set; }
        public string name { get; set; }
        public bool managed { get; set; }
        public string id { get; set; }
        public bool available { get; set; }
        public bool animated { get; set; }
    }

    public class Members {
        public User user { get; set; }
        public List<string> roles { get; set; }
        public bool mute { get; set; }
        public DateTime joined_at { get; set; }
        public string hoisted_role { get; set; }
        public bool deaf { get; set; }
        public string nick { get; set; }
        public object premium_since { get; set; }
        public bool? pending { get; set; }
        public object communication_disabled_until { get; set; }
        public object avatar { get; set; }
    }

    public class EntityMetadata {
        public string location { get; set; }
    }

    public class GuildScheduledEvent {
        public int status { get; set; }
        public List<object> sku_ids { get; set; }
        public DateTime scheduled_start_time { get; set; }
        public DateTime scheduled_end_time { get; set; }
        public int privacy_level { get; set; }
        public string name { get; set; }
        public string image_hash { get; set; }
        public string id { get; set; }
        public string guild_id { get; set; }
        public int entity_type { get; set; }
        public EntityMetadata entity_metadata { get; set; }
        public object entity_id { get; set; }
        public string description { get; set; }
        public object channel_id { get; set; }
    }

    public class Guild {
        public List<VoiceState> voice_states { get; set; }
        public List<Channelss> channels { get; set; }
        public List<Sticker> stickers { get; set; }
        public string name { get; set; }
        public int mfa_level { get; set; }
        public int nsfw_level { get; set; }
        public int default_message_notifications { get; set; }
        public List<object> stage_instances { get; set; }
        public string vanity_url_code { get; set; }
        public string rules_channel_id { get; set; }
        public int system_channel_flags { get; set; }
        public int member_count { get; set; }
        public ApplicationCommandCounts application_command_counts { get; set; }
        public int max_video_channel_users { get; set; }
        public string discovery_splash { get; set; }
        public string afk_channel_id { get; set; }
        public string splash { get; set; }
        public List<string> features { get; set; }
        public int premium_subscription_count { get; set; }
        public bool lazy { get; set; }
        public int verification_level { get; set; }
        public string preferred_locale { get; set; }
        public List<Roless> roles { get; set; }
        public GuildHashes guild_hashes { get; set; }
        public List<Emoji> emojis { get; set; }
        public string description { get; set; }
        public int premium_tier { get; set; }
        public int application_command_count { get; set; }
        public List<object> threads { get; set; }
        public List<Member> members { get; set; }
        public string owner_id { get; set; }
        public string system_channel_id { get; set; }
        public int afk_timeout { get; set; }
        public string icon { get; set; }
        public List<GuildScheduledEvent> guild_scheduled_events { get; set; }
        public int max_members { get; set; }
        public bool large { get; set; }
        public string public_updates_channel_id { get; set; }
        public string id { get; set; }
        public string banner { get; set; }
        public string region { get; set; }
        public object hub_type { get; set; }
        public List<object> embedded_activities { get; set; }
        public bool nsfw { get; set; }
        public List<Presence> presences { get; set; }
        public bool premium_progress_bar_enabled { get; set; }
        public object application_id { get; set; }
        public DateTime joined_at { get; set; }
        public int explicit_content_filter { get; set; }
        public bool? unavailable { get; set; }
    }

    public class Personalization {
        public bool consented { get; set; }
    }

    public class Consents {
        public Personalization personalization { get; set; }
    }

    public class ConnectedAccount {
        public int visibility { get; set; }
        public bool verified { get; set; }
        public string type { get; set; }
        public bool show_activity { get; set; }
        public bool revoked { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public bool friend_sync { get; set; }
        public string access_token { get; set; }
    }

    public class V {
        public int v { get; set; }
        public string user_settings_proto { get; set; }
        public UserSettings user_settings { get; set; }
        public List<UserGuildSetting> user_guild_settings { get; set; }
        public User user { get; set; }
        public object tutorial { get; set; }
        public List<Session> sessions { get; set; }
        public string session_id { get; set; }
        public List<Relationship> relationships { get; set; }
        public List<ReadState> read_state { get; set; }
        public List<PrivateChannel> private_channels { get; set; }
        public List<Presence> presences { get; set; }
        public Notes notes { get; set; }
        public List<Guild> guilds { get; set; }
        public List<object> guild_join_requests { get; set; }
        public List<List<object>> guild_experiments { get; set; }
        public List<string> geo_ordered_rtc_regions { get; set; }
        public int friend_suggestion_count { get; set; }
        public List<List<object>> experiments { get; set; }
        public string country_code { get; set; }
        public Consents consents { get; set; }
        public List<ConnectedAccount> connected_accounts { get; set; }
        public string analytics_token { get; set; }
        public List<string> _trace { get; set; }
    }

    public class DataReady {
        public string t { get; set; }
        public int s { get; set; }
        public int op { get; set; }
        public V d { get; set; }
    }


}
