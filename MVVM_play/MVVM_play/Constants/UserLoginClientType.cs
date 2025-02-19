// -------------------------------------------------------------------------
//  Copyright © 2019 Province of British Columbia
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// -------------------------------------------------------------------------

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MVVM_play.Constants;


/// <summary>
/// Represents the type of login client used.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserLoginClientType
{
    /// <summary>
    /// Login from Health Gateway web app.
    /// </summary>
    Web,

    /// <summary>
    /// Login from Health Gateway Android mobile app.
    /// </summary>
    Android,

    /// <summary>
    /// Login from Health Gateway iOS mobile app.
    /// </summary>
    [EnumMember(Value = "iOS")]
    Ios,

    /// <summary>
    /// Login from Health Gateway mobile app.
    /// </summary>
    Mobile,

    /// <summary>
    /// Login from Health Gateway Salesforce app.
    /// </summary>
    Salesforce,
}
