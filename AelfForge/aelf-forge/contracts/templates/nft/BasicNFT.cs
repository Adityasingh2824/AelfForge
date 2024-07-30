using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.NFT
{
    public partial class BasicNFTContract : BasicNFTContractContainer.BasicNFTContractBase
    {
        // State variables to store token and owner information
        private MapToUInt64<Hash> _ownerOf; 
        private MapToUInt64<Hash> _balanceOf;
        private Map<Hash, string> _tokenMetadata;

        public override Empty Create(CreateInput input)
        {
            Hash tokenId = Context.TransactionId; // Generate a unique token ID (you can use other methods)

            Assert(!_ownerOf.ContainsKey(tokenId), "Token already exists."); // Check if token exists

            State.TokenInfo[tokenId] = new TokenInfo
            {
                Owner = Context.Sender, 
                MetadataUrl = input.MetadataUrl // Store metadata URL
            };

            _ownerOf[tokenId] = Context.Sender;
            _balanceOf[Context.Sender] = _balanceOf[Context.Sender] + 1;
            _tokenMetadata[tokenId] = input.MetadataUrl;

            Context.Fire(new Created { TokenId = tokenId, Owner = Context.Sender, MetadataUrl = input.MetadataUrl });

            return new Empty();
        }

        public override Empty TransferFrom(TransferFromInput input)
        {
            Assert(input.From != input.To, "Cannot transfer to self.");
            Assert(_ownerOf[input.TokenId] == input.From, "Sender is not the owner."); // Check ownership
            Assert(State.Approved[input.TokenId][input.From] == input.To, "Not approved for transfer."); // Check approval

            _ownerOf[input.TokenId] = input.To;
            _balanceOf[input.From] = _balanceOf[input.From] - 1;
            _balanceOf[input.To] = _balanceOf[input.To] + 1;
            State.Approved[input.TokenId].Remove(input.From); // Clear approval after transfer

            Context.Fire(new Transferred { From = input.From, To = input.To, TokenId = input.TokenId });

            return new Empty();
        }

        // ... other standard NFT functions (OwnerOf, BalanceOf, Approve, etc.)

        #region Views
        
        public override Address GetOwnerOf(Hash input)
        {
            return _ownerOf[input];
        }

        public override UInt64Value GetBalanceOf(Address input)
        {
            return new UInt64Value { Value = _balanceOf[input] };
        }

        public override StringValue GetTokenMetadata(Hash input)
        {
            return new StringValue { Value = _tokenMetadata[input] };
        }

        #endregion
    }
}
