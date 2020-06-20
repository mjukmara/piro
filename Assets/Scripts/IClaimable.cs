public interface IClaimable
{
    bool IsClaimed();
    bool IsClaimedBy(IClaimant claimant);
    bool SetClaimant(IClaimant claimant);
    bool UnsetClaimant(IClaimant claimant);
    IClaimant GetClaimant();
}
