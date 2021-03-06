﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.SqlTypes;
using GeoAPI.Geometries;
using GeoAPI.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microsoft.EntityFrameworkCore.SqlServer.Storage.ValueConversion.Internal
{
    /// <summary>
    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class GeometryValueConverter<TGeometry> : ValueConverter<TGeometry, SqlBytes>
    where TGeometry : IGeometry
    {
        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public GeometryValueConverter(IBinaryGeometryReader reader, IBinaryGeometryWriter writer)
            : base(
                g => new SqlBytes(writer.Write(g)),
                b => (TGeometry)reader.Read(b.Value))
        {
        }
    }
}
