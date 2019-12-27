using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Window
{
    /// <summary>
    /// Reference dll: COM.NetFwTypeLib
    /// </summary>
    public class WinFirewall
    {
        public static bool AddRule(string ruleName, string applicationPath, string description = "")
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            if (isRuleExist(firewallPolicy, ruleName, applicationPath))
                return true;

            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule.Name = ruleName; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            firewallRule.ApplicationName = applicationPath;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Description = description;
            firewallRule.Enabled = true;

            firewallPolicy.Rules.Add(firewallRule);

            return isRuleExist(firewallPolicy, ruleName, applicationPath);
        }

        public static bool AddRule(string ruleName, int port, string description = "")
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            if (isRuleExist(firewallPolicy, ruleName, port))
                return true;

            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule.Name = ruleName; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            firewallRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            firewallRule.Description = description;
            firewallRule.LocalPorts = port.ToString();
            firewallRule.Enabled = true;

            firewallPolicy.Rules.Add(firewallRule);

            return isRuleExist(firewallPolicy, ruleName, port);
        }

        public static bool RemoveRule(string ruleName)
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            if (!isRuleExist(firewallPolicy, ruleName))
                return true;

            firewallPolicy.Rules.Remove(ruleName);

            return !isRuleExist(firewallPolicy, ruleName);
        }

        private static bool isRuleExist(INetFwPolicy2 policy, string ruleName)
        {
            return policy.Rules.Cast<INetFwRule>().Any(rule => rule.Name == ruleName);
        }

        private static bool isRuleExist(INetFwPolicy2 policy, string ruleName, string applicationPath)
        {
            return policy.Rules.Cast<INetFwRule>().Any(rule => rule.Name == ruleName && rule.ApplicationName == applicationPath);
        }

        private static bool isRuleExist(INetFwPolicy2 policy, string ruleName, int port)
        {
            return policy.Rules.Cast<INetFwRule>().Any(rule => rule.Name == ruleName && rule.LocalPorts == port.ToString());
        }
    }
}
