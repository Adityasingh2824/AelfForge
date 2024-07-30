using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.NFT
{
    public partial class ERC721MetadataContract : ERC721MetadataContractContainer.ERC721MetadataContractBase
    {
        public override Empty SetTokenMetadata(SetTokenMetadataInput input)
        {
            // Access Control (Only the owner of the token can set metadata)
            Assert(State.BasicNFTContract.GetOwnerOf(input.TokenId) == Context.Sender, "Not token owner."); 

            // Input Validation (Optional)
            // You might add checks for maximum length or prohibited characters in metadata fields

            State.TokenMetadata[input.TokenId] = new TokenMetadata
            {
                Name = input.Name,
                Symbol = input.Symbol,
                Description = input.Description // Optional
            };
            
            return new Empty();
        }

        #region Views

        public override StringValue GetTokenName(Hash input)
        {
            return new StringValue { Value = State.TokenMetadata[input].Name };
        }

        public override StringValue GetTokenSymbol(Hash input)
        {
            return new StringValue { Value = State.TokenMetadata[input].Symbol };
        }

        public override StringValue GetTokenDescription(Hash input) // Optional
        {
            return new StringValue { Value = State.TokenMetadata[input].Description };
        }

        #endregion
    }
}
