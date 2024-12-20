﻿namespace Tribler.API.Extension;
public static class HttpClientExtensions
{
    internal static Task<HttpResponseMessage> PatchAsync(this HttpClient client,
        string requestUri, HttpContent content)
    {
        return client.PatchAsync(CreateUri(requestUri), content);
    }

    internal static Task<HttpResponseMessage> PatchAsync(this HttpClient client,
        Uri requestUri, HttpContent content)
    {
        return client.PatchAsync(requestUri, content, CancellationToken.None);
    }

    internal static Task<HttpResponseMessage> PatchAsync(this HttpClient client,
        string requestUri, HttpContent content, CancellationToken cancellationToken)
    {
        return client.PatchAsync(CreateUri(requestUri), content, cancellationToken);
    }

    internal static Task<HttpResponseMessage> PatchAsync(this HttpClient client,
        Uri requestUri, HttpContent content, CancellationToken cancellationToken)
    {
        return client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
        {
            Content = content
        }, cancellationToken);
    }

    private static Uri CreateUri(string uri)
    {
        return (string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute))!;
    }
}