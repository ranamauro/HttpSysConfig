namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Runtime.InteropServices;

    class SecurityInformation
    {
        public enum SI_ACCESS_FLAGS : uint
        {
            SI_ACCESS_SPECIFIC = 0x00010000,
            SI_ACCESS_GENERAL = 0x00020000,
            SI_ACCESS_CONTAINER = 0x00040000, // general access, container-only
            SI_ACCESS_PROPERTY = 0x00080000,
        }

        public enum SI_OBJECT_INFO_FLAGS : uint
        {
            SI_EDIT_PERMS = 0x00000000, // always implied
            SI_EDIT_OWNER = 0x00000001,
            SI_EDIT_AUDITS = 0x00000002,
            SI_CONTAINER = 0x00000004,
            SI_READONLY = 0x00000008,
            SI_ADVANCED = 0x00000010,
            SI_RESET = 0x00000020, // equals to SI_RESET_DACL|SI_RESET_SACL|SI_RESET_OWNER
            SI_OWNER_READONLY = 0x00000040,
            SI_EDIT_PROPERTIES = 0x00000080,
            SI_OWNER_RECURSE = 0x00000100,
            SI_NO_ACL_PROTECT = 0x00000200,
            SI_NO_TREE_APPLY = 0x00000400,
            SI_PAGE_TITLE = 0x00000800,
            SI_SERVER_IS_DC = 0x00001000,
            SI_RESET_DACL_TREE = 0x00004000,
            SI_RESET_SACL_TREE = 0x00008000,
            SI_OBJECT_GUID = 0x00010000,
            SI_EDIT_EFFECTIVE = 0x00020000,
            SI_RESET_DACL = 0x00040000,
            SI_RESET_SACL = 0x00080000,
            SI_RESET_OWNER = 0x00100000,
            SI_NO_ADDITIONAL_PERMISSION = 0x00200000,
            SI_MAY_WRITE = 0x10000000, // not sure if user can write permission
            SI_EDIT_ALL = (SI_EDIT_PERMS | SI_EDIT_OWNER | SI_EDIT_AUDITS),
        }

        public enum SI_PAGE_TYPE
        {
            SI_PAGE_PERM = 0,
            SI_PAGE_ADVPERM = 1,
            SI_PAGE_AUDIT = 2,
            SI_PAGE_OWNER = 3,
            SI_PAGE_EFFECTIVE = 4
        }

        [ComImport]
        [Guid("965fc360-16ff-11d0-91cb-00aa00bbb723")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        unsafe interface ISecurityInformation
        {
            uint GetAccessRights([In] ref Guid pGuidObjectType, uint dwFlags, out IntPtr ppAccess, out uint pcAccesses, out uint piDefaultAccess);
            // uint GetInheritTypes(out SI_INHERIT_TYPE *ppInheritTypes, out uint pcInheritTypes);
            uint GetObjectInformation(ref SI_OBJECT_INFO pObjectInfo);
            uint GetSecurity(uint RequestedInformation, out IntPtr ppSecurityDescriptor, bool fDefault);
            uint MapGeneric([In] ref Guid pGuidObjectType, out ushort pAceFlags, out uint pMask);
            uint PropertySheetPageCallback(IntPtr hwnd, ushort uMsg, SI_PAGE_TYPE uPage);
            uint SetSecurity(uint SecurityInformation, IntPtr pSecurityDescriptor);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SI_INHERIT_TYPE
        {
            public IntPtr pguid;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SI_OBJECT_INFO
        {
            public SI_OBJECT_INFO_FLAGS dwFlags;
            public IntPtr hInstance;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszServerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszObjectName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszPageTitle;
            public Guid guidObjectType;
        }

        [ComVisible(true)]
        public unsafe class HttpConfigUrlAclEntrySecurityInformation : ISecurityInformation
        {

            static readonly Guid IID_ISecurityInformation = new Guid("965fc360-16ff-11d0-91cb-00aa00bbb723");
            const uint E_FAIL = 0x80004005;
            const uint E_NOINTERFACE = 0x80004002;
            const uint E_NOTIMPL = 0x80004001;
            const uint GENERIC_ALL = 0x10000000;
            const uint GENERIC_EXECUTE = 0x20000000;
            const uint GENERIC_READ = 0x80000000;
            const uint GENERIC_WRITE = 0x40000000;
            const uint S_OK = 0;
            const uint SI_ADVANCED = 0x00000010;
            const uint SI_EDIT_ALL = (SI_EDIT_PERMS | SI_EDIT_OWNER | SI_EDIT_AUDITS);
            const uint SI_EDIT_AUDITS = 0x00000002;
            const uint SI_EDIT_OWNER = 0x00000001;
            const uint SI_EDIT_PERMS = 0x00000000;

            public static void EditSecurity()
            {
                ISecurityInformation editor = new HttpConfigUrlAclEntrySecurityInformation();
                IntPtr fp = Marshal.GetComInterfaceForObject(editor, typeof(ISecurityInformation));
                bool success = EditSecurity(IntPtr.Zero, fp);
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine(success + ":" + errorCode);
                Marshal.Release(fp);
            }

            public uint GetAccessRights(ref Guid pGuidObjectType, uint dwFlags, out IntPtr ppAccess, out uint pcAccesses, out uint piDefaultAccess)
            {
                throw new NotImplementedException();
            }

            // public uint GetInheritTypes(out SI_INHERIT_TYPE *ppInheritTypes, out uint pcInheritTypes)
            // {
            //     throw new NotImplementedException();
            // }

            public uint GetObjectInformation(ref SI_OBJECT_INFO pObjectInfo)
            {
                pObjectInfo.dwFlags = SI_OBJECT_INFO_FLAGS.SI_EDIT_ALL | SI_OBJECT_INFO_FLAGS.SI_ADVANCED;
                pObjectInfo.pszObjectName = "TestObject";
                return S_OK;
            }

            public uint GetSecurity(uint RequestedInformation, out IntPtr ppSecurityDescriptor, bool fDefault)
            {
                throw new NotImplementedException();
            }

            public uint MapGeneric(ref Guid pGuidObjectType, out ushort pAceFlags, out uint pMask)
            {
                throw new NotImplementedException();
            }

            public uint PropertySheetPageCallback(IntPtr hwnd, ushort uMsg, SI_PAGE_TYPE uPage)
            {
                throw new NotImplementedException();
            }

            public uint SetSecurity(uint SecurityInformation, IntPtr pSecurityDescriptor)
            {
                throw new NotImplementedException();
            }

            [DllImport("aclui.dll", SetLastError = true)]
            static extern bool EditSecurity(IntPtr hwndOwner, IntPtr psi);

            [DllImport("advapi32.dll", SetLastError = true)]
            static extern void MapGenericMask(); // TODO
        }
    }
}
