# Integration testing

The integration suite starts an isolated stack with Testcontainers:

- Lemmy `dessalines/lemmy:0.19.20`
- PostgreSQL `postgres:16-alpine`
- pict-rs `asonix/pictrs:0.5.16`

Only the Lemmy API port is published to the host. PostgreSQL and pict-rs remain on a
private Docker network. The fixture creates the site administrator, enables open
registration, registers representative users, and creates community, post, comment,
private-message, report, moderation, custom-emoji, and media data.

Run the same split used by CI:

```shell
dotnet test Lemmy.Net.sln --filter 'Category!=Integration'
dotnet test Lemmy.Net.Tests/Lemmy.Net.Tests.csproj --filter 'Category=Integration'
```

Container logs are always written to `container-logs` below the test working
directory. Set `LEMMY_TEST_LOG_DIR` to an absolute path to choose another location. CI uploads the TRX
and all container logs if the integration job fails.

## Coverage

The suite exercises:

- site discovery/editing, login, registration, authentication validation, user
  lookup, search, object resolution, settings, counts, captcha, sessions, replies,
  mentions, and mark-all-read;
- community create/read/update/list/follow/block/hide and pagination;
- post and comment create/read/update/list, pagination, votes, saves, read/hide,
  distinguish, lock, feature, remove, reports, report resolution, and likes;
- private-message create/read/update/delete, read state, pagination, reporting,
  report listing, and resolution;
- bans, person blocking, moderator assignment, moderator log, banned-person and
  federated-instance reads;
- authenticated multipart image upload, download, user/admin media listing,
  deletion, and custom emoji create/update/delete.

The following endpoints are deliberately not exercised by the single-instance PR
stack:

- email/reset-token flows: `PasswordReset`, `PasswordChangeAfterReset`, and
  `VerifyEmail`;
- multi-instance federation behavior: `BlockInstance`;
- interactive TOTP enrollment: `GenerateTotpSecret` and `UpdateTotp`;
- alternate bootstrap and registration-approval modes: `CreateSite`,
  `GetRegistrationApplication`, `ListRegistrationApplications`,
  `ListAllRegistrationApplications`, and `ApproveRegistrationApplication`;
- irreversible administrator/account operations: `LeaveAdmin`, `AddAdmin`,
  `DeleteAccount`, and the four `Purge*` methods;
- ownership transfer: `TransferCommunity`;
- notification mutations requiring separately timed inbox delivery:
  `MarkCommentReplyAsRead` and `MarkPersonMentionAsRead`;
- external URL metadata fetching: `GetSiteMetadata`;
- settings import/export, password rotation, and logout, which invalidate or replace
  the shared authenticated session used by the scenario suite.

Those exclusions are intentional capability boundaries, not silent coverage gaps.
