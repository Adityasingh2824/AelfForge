using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.Token
{
    public partial class MintableTokenContract : MintableTokenContractContainer.MintableTokenContractBase
    {
        public override Empty Mint(MintInput input)
        {
            // Access Control (Only the owner or authorized minter can mint)
            Assert(Context.Sender == State.Owner.Value || State.Minters[Context.Sender], "No permission to mint.");

            // Input Validation
            Assert(input.Amount > 0, "Invalid mint amount.");

            // Minting Logic
            State.TokenInfo.TotalSupply += input.Amount;
            State.Balances[input.To] += input.Amount;

            // Event Emission
            Context.Fire(new Minted
            {
                Minter = Context.Sender,
                To = input.To,
                Amount = input.Amount
            });

            return new Empty();
        }

        // ... (Optional) Add functions for managing minters (AddMinter, RemoveMinter)
    }
}
