using Passes.Models.JsonConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
   public class PassDetailModel
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("xml_id")]
        public string? xml_id { get; set; }

        [JsonPropertyName("request_num")]
        public string? request_num { get; set; }

        [JsonPropertyName("pass_num")]
        public string? pass_num { get; set; }

        [JsonPropertyName("date_from")]
        public string? date_from { get; set; }

        [JsonPropertyName("date_to")]
        public string? date_to { get; set; }

        [JsonPropertyName("time_from")]
        public string? time_from { get; set; }

        [JsonPropertyName("time_to")]
        public string? time_to { get; set; }

        [JsonPropertyName("date_from_confirm")]
        public string? date_from_confirm { get; set; }

        [JsonPropertyName("date_to_confirm")]
        public string? date_to_confirm { get; set; }

        [JsonPropertyName("time_from_confirm")]
        public string? time_from_confirm { get; set; }

        [JsonPropertyName("time_to_confirm")]
        public string? time_to_confirm { get; set; }

        [JsonPropertyName("day_and_night")]
        public bool day_and_night { get; set; }

        [JsonPropertyName("day_and_night_confirm")]
        public bool day_and_night_confirm { get; set; }

        [JsonPropertyName("created")]
        public string? created { get; set; }

        [JsonPropertyName("created_by")]
        public string? created_by { get; set; }

        [JsonPropertyName("updated_by")]
        public string? updated_by { get; set; }

        [JsonPropertyName("pass_state_id")]
        public string? pass_state_id { get; set; }

        [JsonPropertyName("way_to_get_documents_id")]
        public string? way_to_get_documents_id { get; set; }

        [JsonPropertyName("pass_type_id")]
        public string? pass_type_id { get; set; }

        [JsonPropertyName("pass_buro_user_id")]
        public string? pass_buro_user_id { get; set; }

        [JsonPropertyName("is_tmc")]
        public string? is_tmc { get; set; }

        [JsonPropertyName("is_internal_movement")]
        public string? is_internal_movement { get; set; }

        [JsonPropertyName("transit_from_object_id")]
        public string? transit_from_object_id { get; set; }

        [JsonPropertyName("transit_to_object_id")]
        public string? transit_to_object_id { get; set; }

        [JsonPropertyName("is_transit")]
        public string? is_transit { get; set; }

        [JsonPropertyName("is_gsm")]
        public string? is_gsm { get; set; }

        [JsonPropertyName("comment")]
        public string? comment { get; set; }

        [JsonPropertyName("waybills")]
        public string? waybills { get; set; }

        [JsonPropertyName("curator")]
        [JsonConverter(typeof(CuratorJsonConverter))]
        public object? curator { get; set; }

        [JsonPropertyName("curator_position")]
        public string? curator_position { get; set; }

        [JsonPropertyName("contract_name")]
        public string? contract_name { get; set; }

        [JsonPropertyName("contract_num")]
        public string? contract_num { get; set; }

        [JsonPropertyName("contract_date")]
        public string? contract_date { get; set; }

        [JsonPropertyName("can_bring_goods")]
        public bool can_bring_goods { get; set; }

        [JsonPropertyName("return_date")]
        public string? return_date { get; set; }

        [JsonPropertyName("secret_code")]
        public string? secret_code { get; set; }

        [JsonPropertyName("goal")]
        public string? goal { get; set; }

        [JsonPropertyName("registered_by")]
        public string? registered_by { get; set; }

        [JsonPropertyName("register_date")]
        public string? register_date { get; set; }

        [JsonPropertyName("is_umts")]
        public string? is_umts { get; set; }

        [JsonPropertyName("transit_from_object_text")]
        public string? transit_from_object_text { get; set; }

        [JsonPropertyName("transit_to_object_text")]
        public string? transit_to_object_text { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_id")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_state_id { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_code")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_state_code { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_name")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_state_name { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_state_is_deleted")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_state_is_deleted { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_id")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_type_id { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_name")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_type_name { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_disabled")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_type_disabled { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_numerator_string")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_type_numerator_string { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_type_is_material")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_type_is_material { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_way_to_get_documents_id")]
        public string? SINERGO_APP_ENTITY_PASSES_way_to_get_documents_id { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_way_to_get_documents_name")]
        public string? SINERGO_APP_ENTITY_PASSES_way_to_get_documents_name { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_LOGIN")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_LOGIN { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_EMAIL")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_EMAIL { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_ACTIVE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_ACTIVE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_BLOCKED")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_BLOCKED { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_LAST_ACTIVITY_DATE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_LAST_ACTIVITY_DATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_SECOND_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_SECOND_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_LAST_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_LAST_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_TITLE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_TITLE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_EXTERNAL_AUTH_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_EXTERNAL_AUTH_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_XML_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_XML_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_BX_USER_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_BX_USER_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_CONFIRM_CODE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_CONFIRM_CODE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_LID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_LID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_LANGUAGE_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_LANGUAGE_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_TIME_ZONE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_TIME_ZONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_TIME_ZONE_OFFSET")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_TIME_ZONE_OFFSET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PROFESSION")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PROFESSION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PHONE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PHONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_MOBILE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_MOBILE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_WWW")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_WWW { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_ICQ")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_ICQ { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_FAX")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_FAX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PAGER")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PAGER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_STREET")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_STREET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_MAILBOX")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_MAILBOX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_CITY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_CITY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_STATE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_STATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_ZIP")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_ZIP { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_COUNTRY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_COUNTRY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_BIRTHDAY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_BIRTHDAY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_GENDER")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_GENDER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PHOTO")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_PHOTO { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_PERSONAL_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_COMPANY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_COMPANY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_DEPARTMENT")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_DEPARTMENT { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PHONE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PHONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_POSITION")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_POSITION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_WWW")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_WWW { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_FAX")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_FAX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PAGER")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PAGER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_STREET")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_STREET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_MAILBOX")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_MAILBOX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_CITY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_CITY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_STATE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_STATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_ZIP")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_ZIP { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_COUNTRY")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_COUNTRY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PROFILE")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_PROFILE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_LOGO")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_LOGO { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_WORK_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_WORK_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_creator_user_ADMIN_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_creator_user_ADMIN_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_LOGIN")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_LOGIN { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_EMAIL")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_EMAIL { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_ACTIVE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_ACTIVE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_BLOCKED")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_BLOCKED { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_LAST_ACTIVITY_DATE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_LAST_ACTIVITY_DATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_SECOND_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_SECOND_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_LAST_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_LAST_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_TITLE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_TITLE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_EXTERNAL_AUTH_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_EXTERNAL_AUTH_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_XML_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_XML_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_BX_USER_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_BX_USER_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_CONFIRM_CODE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_CONFIRM_CODE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_LID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_LID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_LANGUAGE_ID")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_LANGUAGE_ID { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_TIME_ZONE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_TIME_ZONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_TIME_ZONE_OFFSET")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_TIME_ZONE_OFFSET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PROFESSION")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PROFESSION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PHONE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PHONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_MOBILE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_MOBILE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_WWW")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_WWW { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_ICQ")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_ICQ { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_FAX")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_FAX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PAGER")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PAGER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_STREET")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_STREET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_MAILBOX")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_MAILBOX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_CITY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_CITY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_STATE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_STATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_ZIP")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_ZIP { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_COUNTRY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_COUNTRY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_BIRTHDAY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_BIRTHDAY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_GENDER")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_GENDER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PHOTO")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_PHOTO { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_PERSONAL_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_COMPANY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_COMPANY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_DEPARTMENT")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_DEPARTMENT { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PHONE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PHONE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_POSITION")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_POSITION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_WWW")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_WWW { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_FAX")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_FAX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PAGER")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PAGER { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_STREET")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_STREET { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_MAILBOX")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_MAILBOX { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_CITY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_CITY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_STATE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_STATE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_ZIP")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_ZIP { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_COUNTRY")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_COUNTRY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PROFILE")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_PROFILE { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_LOGO")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_LOGO { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_WORK_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_pass_buro_user_ADMIN_NOTES")]
        public string? SINERGO_APP_ENTITY_PASSES_pass_buro_user_ADMIN_NOTES { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_register_user_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_register_user_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_register_user_SECOND_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_register_user_SECOND_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_register_user_LAST_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_register_user_LAST_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_register_user_WORK_COMPANY")]
        public string? SINERGO_APP_ENTITY_PASSES_register_user_WORK_COMPANY { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_register_user_WORK_POSITION")]
        public string? SINERGO_APP_ENTITY_PASSES_register_user_WORK_POSITION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_transit_from_object_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_transit_from_object_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_transit_from_object_LOCATION")]
        public string? SINERGO_APP_ENTITY_PASSES_transit_from_object_LOCATION { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_transit_to_object_NAME")]
        public string? SINERGO_APP_ENTITY_PASSES_transit_to_object_NAME { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_transit_to_object_LOCATION")]
        public string? SINERGO_APP_ENTITY_PASSES_transit_to_object_LOCATION { get; set; }

        [JsonPropertyName("register_user")]
        public string? register_user { get; set; }

        [JsonPropertyName("visitors")]
        public List<Visitor>? visitors { get; set; }

        [JsonPropertyName("objects")]
        public List<Object>? objects { get; set; }

        [JsonPropertyName("negotiators")]
        public List<Negotiator>? negotiators { get; set; }

        [JsonPropertyName("author")]
        public string? author { get; set; }

        [JsonPropertyName("mol")]
        public string? mol { get; set; }

        [JsonPropertyName("vehicles")]
        public List<Vehicle>? vehicles { get; set; }

        [JsonPropertyName("goods")]
        [JsonConverter(typeof(GoodsJsonConverter))]
        public object? list_of_tmc { get; set; }

        [JsonPropertyName("visit_goal")]
        public VisitGoal? visitGoal { get; set; }

        [JsonPropertyName("areas")]
        public Areas? Areas { get; set; }

        [JsonPropertyName("associated_pass")]
        public AssociatedPass? AssociatedPass { get; set; }

        [JsonPropertyName("documents")]
        public List<Document>? Documents { get; set; }

        [JsonPropertyName("supplier_name")]
        public string? SupplierName { get; set; }

        [JsonPropertyName("executor_name")]
        public string? ExecutorName { get; set; }

        [JsonPropertyName("children")]
        public ChildrenModel? Children { get; set; }

    }

   public class Negotiator
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("NAME")]
        public string NAME { get; set; }

        [JsonPropertyName("SECOND_NAME")]
        public string SECOND_NAME { get; set; }

        [JsonPropertyName("LAST_NAME")]
        public string LAST_NAME { get; set; }

        [JsonPropertyName("WORK_POSITION")]
        public string WORK_POSITION { get; set; }

        [JsonPropertyName("WORK_PROFILE")]
        public string WORK_PROFILE { get; set; }

        [JsonPropertyName("WORK_COMPANY")]
        public string WORK_COMPANY { get; set; }
    }

    public class Object
    {
        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_OBJECTS_object_name")]
        public string SINERGO_APP_ENTITY_PASSES_OBJECTS_object_name { get; set; }
    }

    public class Visitor
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("second_name")]
        public string? SecondName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("birth_date")]
        public string? BirthDate { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("number_of_pass")]
        public string? number_of_pass { get; set; }

        [JsonPropertyName("date_of_pass")]
        public string? date_of_pass { get; set; }

        [JsonPropertyName("is_employee_of_mmk")]
        public bool? is_employee_of_mmk { get; set; }

    }

    public class VisitGoal
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }
    }

    public class Vehicle
    {
        [JsonPropertyName("brand")]
        public string? brand { get; set; }

        [JsonPropertyName("number")]
        public string? number { get; set; }
    }

    public class Areas
    {
        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_AREAS_area_import_name")]
        public string? ImportName { get; set; }

        [JsonPropertyName("SINERGO_APP_ENTITY_PASSES_AREAS_area_export_name")]
        public string? ExportName { get; set; }
    }

    public class AssociatedPass
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }

    public class Document
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("original_name")]
        public string? OriginalName { get; set; }
    }

    public class CuratorModel
    {
        [JsonPropertyName("ID")]
        public string? Id { get; set; }
        [JsonPropertyName("LAST_NAME")]
        public string? LastName { get; set; }
        [JsonPropertyName("NAME")]
        public string? Name { get; set; }
        [ JsonPropertyName("SECOND_NAME")]
        public string? SecondName { get; set; }
        [JsonPropertyName("WORK_COMPANY")]
        public string? WorkCompany { get; set; }
        [JsonPropertyName("WORK_POSITION")]
        public string? WorkPosition { get; set; }
        [JsonPropertyName("WORK_PROFILE")]
        public string? WorkProfile { get; set; }
    }

    public class GoodsModel
    {
        [JsonPropertyName("count")]
        public string? Count { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }

    public class RootPassDetailModel
    {
        [JsonPropertyName("Pass")]
        public PassDetailModel? Pass { get; set; }
    }


}
