using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.Token
{
    public partial class BasicTokenContract : BasicTokenContractContainer.BasicTokenContractBase
    {
        public override Empty Initialize(InitializeInput input)
        {
            State.TokenInfo.Symbol = input.Symbol;
            State.TokenInfo.TokenName = input.TokenName;
            State.TokenInfo.TotalSupply = input.TotalSupply;
            State.TokenInfo.Decimals = input.Decimals;
            State.Balances[Context.Sender] = input.TotalSupply;

            return new Empty();
        }

        public override Empty Transfer(TransferInput input)
        {
            Assert(State.Balances[Context.Sender] >= input.Amount, "Insufficient balance");

            State.Balances[Context.Sender] -= input.Amount;
            State.Balances[input.To] += input.Amount;

            Context.Fire(new Transferred
            {
                From = Context.Sender,
                To = input.To,
                Amount = input.Amount
            });

            return new Empty();
        }

        // ... other standard ERC20 functions (BalanceOf, Allowance, Approve, TransferFrom)

        #region Views

        public override TokenInfo GetTokenInfo(Empty input)
        {
            return State.TokenInfo;
        }

        public override GetBalanceOutput GetBalance(GetBalanceInput input)
        {
            return new GetBalanceOutput
            {
                Balance = State.Balances[input.Owner]
            };
        }

        #endregion
    }
}
