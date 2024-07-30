using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using System.Linq;

namespace AElf.Contracts.NFT
{
    public partial class ERC721EnumerableContract : ERC721EnumerableContractContainer.ERC721EnumerableContractBase
    {
        // State variables to store token and owner information
        private MapToUInt64<Address> _tokenByIndex; 
        private MapToUInt64<Address> _ownedTokensCount;
        private Map<Address, HashList> _ownedTokens;

        #region Overrides

        public override Empty Initialize(InitializeInput input)
        {
            // ... (Your existing initialization logic from BasicNFT.cs)
            return new Empty();
        }

        public override Empty TransferFrom(TransferFromInput input)
        {
            // ... (Your existing TransferFrom logic from BasicNFT.cs)

            // Update ownedTokens for both addresses
            _removeTokenFromOwnerEnumeration(input.From, input.TokenId);
            _addTokenToOwnerEnumeration(input.To, input.TokenId);

            return new Empty();
        }

        #endregion
        
        #region Enumerable

        public override UInt64Value GetTotalSupply(Empty input)
        {
            return new UInt64Value { Value = State.TokenCount.Value };
        }

        public override Hash GetTokenByIndex(UInt64Value input)
        {
            Assert(input.Value < State.TokenCount.Value, "Index out of bounds.");
            return _tokenByIndex[input.Value];
        }

        public override GetTokenIdsInput GetTokenIds(GetTokenIdsInput input)
        {
            HashList tokenIds = _ownedTokens[input.Owner];
            if (input.StartIndex.HasValue && input.Length.HasValue)
            {
                Assert(input.StartIndex.Value < tokenIds.Values.Count, "Invalid start index.");
                var endIndex = System.Math.Min(input.StartIndex.Value + input.Length.Value, tokenIds.Values.Count);
                return new GetTokenIdsInput { Owner = input.Owner, Values = { tokenIds.Values.Skip((int)input.StartIndex.Value).Take((int)input.Length.Value) } };
            }

            return new GetTokenIdsInput { Owner = input.Owner, Values = { tokenIds.Values } };
        }

        #endregion

        #region Private methods

        private void _addTokenToOwnerEnumeration(Address to, Hash tokenId)
        {
            uint256 length = _ownedTokensCount[to];
            _tokenByIndex[length] = tokenId;
            _ownedTokens[to].Values.Add(tokenId);
            _ownedTokensCount[to] = length + 1;
        }

        private void _removeTokenFromOwnerEnumeration(Address from, Hash tokenId)
        {
            // To prevent a gap in from's tokens array, we store the last token in the index of the token to delete, and
            // then delete the last slot (swap and pop).
            uint256 lastTokenIndex = _ownedTokensCount[from] - 1;
            Hash tokenIndex = _ownedTokens[from].Values.IndexOf(tokenId);

            // When the token to delete is the last token, the swap operation is unnecessary
            if (tokenIndex != lastTokenIndex)
            {
                Hash lastTokenId = _ownedTokens[from].Values[(int)lastTokenIndex];

                _ownedTokens[from].Values[(int)tokenIndex] = lastTokenId; // Move the last token to the slot of the to-delete token
                _tokenByIndex[tokenIndex] = lastTokenId; // Update the moved token's index
            }

            // This also deletes the contents at the last position of the array
            _ownedTokens[from].Values.RemoveAt((int)lastTokenIndex);
            _ownedTokensCount[from] = lastTokenIndex; // Update ownedTokensCount
        }

        #endregion
    }
}
