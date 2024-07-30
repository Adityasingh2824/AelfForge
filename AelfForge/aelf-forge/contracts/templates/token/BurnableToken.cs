using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.Token
{
    public partial class BurnableTokenContract : BurnableTokenContractContainer.BurnableTokenContractBase
    {
        public override Empty Burn(BurnInput input)
        {
            Assert(State.Balances[Context.Sender] >= input.Amount, "Burner doesn't own enough tokens.");
            
            State.TokenInfo.TotalSupply -= input.Amount;
            State.Balances[Context.Sender] -= input.Amount;

            Context.Fire(new Burned
            {
                Burner = Context.Sender,
                Amount = input.Amount
            });
            
            return new Empty();
        }
    }
}
