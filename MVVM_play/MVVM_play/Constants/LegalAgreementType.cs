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

namespace MVVM_play.Constants;


/// <summary>
/// The set of Legal Agreement types.
/// </summary>
public enum LegalAgreementType
{
    /// <summary>
    /// The core representing Terms of Service.
    /// </summary>
    [EnumMember(Value = "ToS")]
    TermsOfService,
}
