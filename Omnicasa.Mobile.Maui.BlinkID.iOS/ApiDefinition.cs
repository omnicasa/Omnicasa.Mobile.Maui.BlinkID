using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Omnicasa.Mobile.Maui.BlinkID.iOS
{
    // typedef void (^MBLicenseErrorBlock)(MBLicenseError);
    delegate void MBLicenseErrorBlock(MBLicenseError arg0);

    [BaseType(typeof(NSObject))]
    interface MBMicroblinkSDK
	{
        [Static]
        [Export("sharedInstance")]
        public MBMicroblinkSDK Instance();

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey errorCallback:(MBLicenseErrorBlock _Nullable)errorCallback;
        [Export("setLicenseKey:errorCallback:")]
        void SetLicenseKey(
            string base64LicenseKey,
            [NullAllowed] MBLicenseErrorBlock errorCallback);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBLicenseErrorBlock _Nullable)errorCallback;
        [Export("setLicenseKey:andLicensee:errorCallback:")]
        void SetLicenseKey(
            string base64LicenseKey,
            string licensee,
            [NullAllowed] MBLicenseErrorBlock errorCallback);
    }

    #region DATA
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBStringResult
    {
        // @property(nonatomic, readonly) NSString *value;
        [Export("value")]
        string Value { get; }

        // - (NSString *)valueForAlphabetType:(MBAlphabetType)alphabetType;

        // @property(nonatomic, readonly) CGRect location;
        [Export("location")]
        CGRect Location { get; }

        // - (CGRect)locationForAlphabetType:(MBAlphabetType)alphabetType;

        // @property(nonatomic, readonly) MBSide side;
        [Export("side")]
        MBSide Side { get; }

        // - (MBSide)sideForAlphabetType:(MBAlphabetType)alphabetType;
    }

    // @protocol MBNativeResult;
    public interface IMBNativeResult { }

    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDateResult : IMBNativeResult
    {
        // -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString __attribute__((objc_designated_initializer));
        [Export("initWithDay:month:year:originalDateString:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint day, nint month, nint year, [NullAllowed] string originalDateString);

        // @property (readonly, nonatomic) NSString * _Nullable originalDateString;
        [NullAllowed, Export("originalDateString")]
        string OriginalDateString { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull date;
        [Export("date")]
        NSDate Date { get; }

        // @property (readonly, assign, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, assign, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, assign, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }

        // +(instancetype _Nonnull)dateResultWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString;
        [Static]
        [Export("dateResultWithDay:month:year:originalDateString:")]
        MBDateResult DateResultWithDay(nint day, nint month, nint year, [NullAllowed] string originalDateString);
    }

    // @protocol MBCombinedRecognizerResult
    interface IMBCombinedRecognizerResult { }

    // @protocol MBCombinedRecognizerResult
    [Protocol]
    interface MBCombinedRecognizerResult
    {
        // @required @property (readonly, assign, nonatomic) MBDataMatchResult documentDataMatch;
        [Abstract]
        [Export("documentDataMatch", ArgumentSemantic.Assign)]
        MBDataMatchResult DocumentDataMatch { get; }

        // @required @property (readonly, assign, nonatomic) BOOL scanningFirstSideDone;
        [Abstract]
        [Export("scanningFirstSideDone")]
        bool ScanningFirstSideDone { get; }
    }

    // @protocol MBFaceImageResult;
    public interface IMBFaceImageResult { }

    // @protocol MBFaceImageResult
    [Protocol]
    interface MBFaceImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable faceImage;
        [Abstract]
        [NullAllowed, Export("faceImage")]
        MBImage FaceImage { get; }
    }

    // @protocol MBEncodedFaceImageResult;
    public interface IMBEncodedFaceImageResult { }

    // @protocol MBEncodedFaceImageResult
    [Protocol]
    interface MBEncodedFaceImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFaceImage;
        [Abstract]
        [NullAllowed, Export("encodedFaceImage")]
        NSData EncodedFaceImage { get; }
    }

    // @protocol MBCombinedFullDocumentImageResult;
    public interface IMBCombinedFullDocumentImageResult { }

    // @protocol MBCombinedFullDocumentImageResult
    [Protocol]
    interface MBCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentFrontImage")]
        MBImage FullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentBackImage")]
        MBImage FullDocumentBackImage { get; }
    }

    // @protocol MBEncodedCombinedFullDocumentImageResult;
    public interface IMBEncodedCombinedFullDocumentImageResult { }

    // @protocol MBEncodedCombinedFullDocumentImageResult
    [Protocol]
    interface MBEncodedCombinedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentFrontImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentFrontImage")]
        NSData EncodedFullDocumentFrontImage { get; }

        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentBackImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentBackImage")]
        NSData EncodedFullDocumentBackImage { get; }
    }

    // @protocol IMBAgeResult;
    public interface IMBAgeResult { }

    // @protocol IMBAgeResult
    [Protocol]
    interface MBAgeResult
    {
        // @required @property (assign, nonatomic) NSInteger fullDocumentImageDpi;
        [Abstract]
        [Export("age")]
        int Age { get; set; }
    }

    // @protocol MBDocumentExpirationCheckResult;
    public interface IMBDocumentExpirationCheckResult { }

    // @protocol MBDocumentExpirationCheckResult
    [Protocol]
    interface MBDocumentExpirationCheckResult
    {
        // @required -(BOOL)isExpired;
        [Abstract]
        [Export("isExpired")]
        bool Expired { get; }
    }

    // @protocol MBSignatureImageResult;
    public interface IMBSignatureImageResult { }

    // @protocol MBSignatureImageResult
    [Protocol]
    interface MBSignatureImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable signatureImage;
        [Abstract]
        [NullAllowed, Export("signatureImage")]
        MBImage SignatureImage { get; }
    }

    // @protocol MBEncodedSignatureImageResult;
    public interface IMBEncodedSignatureImageResult { }

    // @protocol MBEncodedSignatureImageResult
    [Protocol]
    interface MBEncodedSignatureImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedSignatureImage;
        [Abstract]
        [NullAllowed, Export("encodedSignatureImage")]
        NSData EncodedSignatureImage { get; }
    }

    // @interface MBMrzResult : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBMrzResult : IMBAgeResult
    {
        // @property (readonly, assign, nonatomic) MBMrtdDocumentType documentType;
        [Export("documentType", ArgumentSemantic.Assign)]
        MBMrtdDocumentType DocumentType { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull primaryID;
        [Export("primaryID", ArgumentSemantic.Strong)]
        string PrimaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull secondaryID;
        [Export("secondaryID", ArgumentSemantic.Strong)]
        string SecondaryID { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuer;
        [Export("issuer", ArgumentSemantic.Strong)]
        string Issuer { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull issuerName;
        [Export("issuerName", ArgumentSemantic.Strong)]
        string IssuerName { get; }

        // @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth", ArgumentSemantic.Strong)]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentNumber;
        [Export("documentNumber", ArgumentSemantic.Strong)]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationality;
        [Export("nationality", ArgumentSemantic.Strong)]
        string Nationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull gender;
        [Export("gender", ArgumentSemantic.Strong)]
        string Gender { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull documentCode;
        [Export("documentCode", ArgumentSemantic.Strong)]
        string DocumentCode { get; }

        // @property (readonly, nonatomic, strong) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry", ArgumentSemantic.Strong)]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt1;
        [Export("opt1", ArgumentSemantic.Strong)]
        string Opt1 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull opt2;
        [Export("opt2", ArgumentSemantic.Strong)]
        string Opt2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull alienNumber;
        [Export("alienNumber", ArgumentSemantic.Strong)]
        string AlienNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull applicationReceiptNumber;
        [Export("applicationReceiptNumber", ArgumentSemantic.Strong)]
        string ApplicationReceiptNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull immigrantCaseNumber;
        [Export("immigrantCaseNumber", ArgumentSemantic.Strong)]
        string ImmigrantCaseNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull mrzText;
        [Export("mrzText", ArgumentSemantic.Strong)]
        string MrzText { get; }

        // @property (readonly, assign, nonatomic) BOOL isParsed;
        [Export("isParsed")]
        bool IsParsed { get; }

        // @property (readonly, assign, nonatomic) BOOL isVerified;
        [Export("isVerified")]
        bool IsVerified { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt1;
        [Export("sanitizedOpt1", ArgumentSemantic.Strong)]
        string SanitizedOpt1 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedOpt2;
        [Export("sanitizedOpt2", ArgumentSemantic.Strong)]
        string SanitizedOpt2 { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedNationality;
        [Export("sanitizedNationality", ArgumentSemantic.Strong)]
        string SanitizedNationality { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedIssuer;
        [Export("sanitizedIssuer", ArgumentSemantic.Strong)]
        string SanitizedIssuer { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentCode;
        [Export("sanitizedDocumentCode", ArgumentSemantic.Strong)]
        string SanitizedDocumentCode { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull sanitizedDocumentNumber;
        [Export("sanitizedDocumentNumber", ArgumentSemantic.Strong)]
        string SanitizedDocumentNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull nationalityName;
        [Export("nationalityName", ArgumentSemantic.Strong)]
        string NationalityName { get; }
    }

    // @interface MBDriverLicenseDetailedInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDriverLicenseDetailedInfo
    {
        // @property (readonly, nonatomic) NSString * _Nullable restrictions;
        [NullAllowed, Export("restrictions")]
        string Restrictions { get; }

        // @property (readonly, nonatomic) NSString * _Nullable endorsements;
        [NullAllowed, Export("endorsements")]
        string Endorsements { get; }

        // @property (readonly, nonatomic) NSString * _Nullable vehicleClass;
        [NullAllowed, Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nullable conditions;
        [NullAllowed, Export("conditions")]
        string Conditions { get; }

        // @property (readonly, nonatomic) NSArray<MBVehicleClassInfo *> * _Nullable vehicleClassesInfo;
        [NullAllowed, Export("vehicleClassesInfo")]
        MBVehicleClassInfo[] VehicleClassesInfo { get; }
    }

    // @interface MBClassInfo : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBClassInfo : INSSecureCoding
    {
        // @property (readonly, assign, nonatomic) MBCountry country;
        [Export("country", ArgumentSemantic.Assign)]
        MBCountry Country { get; }

        // @property (readonly, assign, nonatomic) MBRegion region;
        [Export("region", ArgumentSemantic.Assign)]
        MBRegion Region { get; }

        // @property (readonly, assign, nonatomic) MBType type;
        [Export("type", ArgumentSemantic.Assign)]
        MBType Type { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable countryName;
        [NullAllowed, Export("countryName")]
        string CountryName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoNumericCountryCode;
        [NullAllowed, Export("isoNumericCountryCode")]
        string IsoNumericCountryCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoAlpha2CountryCode;
        [NullAllowed, Export("isoAlpha2CountryCode")]
        string IsoAlpha2CountryCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable isoAlpha3CountryCode;
        [NullAllowed, Export("isoAlpha3CountryCode")]
        string IsoAlpha3CountryCode { get; }
    }

    // @interface MBImageAnalysisResult : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBImageAnalysisResult
    {
        // @property (readonly, assign, nonatomic) BOOL blurred;
        [Export("blurred")]
        bool Blurred { get; }

        // @property (readonly, assign, nonatomic) MBDocumentImageColorStatus documentImageColorStatus;
        [Export("documentImageColorStatus", ArgumentSemantic.Assign)]
        MBDocumentImageColorStatus DocumentImageColorStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus documentImageMoireStatus;
        [Export("documentImageMoireStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus DocumentImageMoireStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus faceDetectionStatus;
        [Export("faceDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus FaceDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus mrzDetectionStatus;
        [Export("mrzDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus MrzDetectionStatus { get; }

        // @property (readonly, assign, nonatomic) MBImageAnalysisDetectionStatus barcodeDetectionStatus;
        [Export("barcodeDetectionStatus", ArgumentSemantic.Assign)]
        MBImageAnalysisDetectionStatus BarcodeDetectionStatus { get; }
    }

    // @interface MBBarcodeElements : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeElements : INSCopying
    {
        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // -(NSString * _Nonnull)getValue:(MBBarcodeElementKey)key;
        [Export("getValue:")]
        string GetValue(MBBarcodeElementKey key);
    }

    // @interface MBBarcodeResult : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBBarcodeResult
    {
        // @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
        [NullAllowed, Export("rawData", ArgumentSemantic.Strong)]
        NSData RawData { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
        [NullAllowed, Export("stringData", ArgumentSemantic.Strong)]
        string StringData { get; }

        // @property (readonly, assign, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { get; }

        // @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
        [Export("barcodeType", ArgumentSemantic.Assign)]
        MBBarcodeType BarcodeType { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull middleName;
        [Export("middleName")]
        string MiddleName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
        [Export("additionalNameInformation")]
        string AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull profession;
        [Export("profession")]
        string Profession { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
        [Export("maritalStatus")]
        string MaritalStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
        [Export("residentialStatus")]
        string ResidentialStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull employer;
        [Export("employer")]
        string Employer { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
        [Export("personalIdNumber")]
        string PersonalIdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
        [Export("documentAdditionalNumber")]
        string DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull street;
        [Export("street")]
        string Street { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull postalCode;
        [Export("postalCode")]
        string PostalCode { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull city;
        [Export("city")]
        string City { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull jurisdiction;
        [Export("jurisdiction")]
        string Jurisdiction { get; }

        // @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }

        // @property (readonly, nonatomic) MBBarcodeElements * _Nullable extendedElements;
        [NullAllowed, Export("extendedElements")]
        MBBarcodeElements ExtendedElements { get; }
    }

    // @interface MBVizResult : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVizResult
    {
        // @property (readonly, nonatomic) NSString * _Nonnull firstName;
        [Export("firstName")]
        string FirstName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull lastName;
        [Export("lastName")]
        string LastName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fullName;
        [Export("fullName")]
        string FullName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fathersName;
        [Export("fathersName")]
        string FathersName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull mothersName;
        [Export("mothersName")]
        string MothersName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull additionalNameInformation;
        [Export("additionalNameInformation")]
        string AdditionalNameInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull localizedName;
        [Export("localizedName")]
        string LocalizedName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull additionalAddressInformation;
        [Export("additionalAddressInformation")]
        string AdditionalAddressInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nullable additionalOptionalAddressInformation;
        [NullAllowed, Export("additionalOptionalAddressInformation")]
        string AdditionalOptionalAddressInformation { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull placeOfBirth;
        [Export("placeOfBirth")]
        string PlaceOfBirth { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull nationality;
        [Export("nationality")]
        string Nationality { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull race;
        [Export("race")]
        string Race { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull religion;
        [Export("religion")]
        string Religion { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull profession;
        [Export("profession")]
        string Profession { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull maritalStatus;
        [Export("maritalStatus")]
        string MaritalStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull residentialStatus;
        [Export("residentialStatus")]
        string ResidentialStatus { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull employer;
        [Export("employer")]
        string Employer { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull sex;
        [Export("sex")]
        string Sex { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult DateOfBirth { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfIssue;
        [Export("dateOfIssue")]
        MBDateResult DateOfIssue { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult DateOfExpiry { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentNumber;
        [Export("documentNumber")]
        string DocumentNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull personalIdNumber;
        [Export("personalIdNumber")]
        string PersonalIdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull documentAdditionalNumber;
        [Export("documentAdditionalNumber")]
        string DocumentAdditionalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nullable documentOptionalAdditionalNumber;
        [NullAllowed, Export("documentOptionalAdditionalNumber")]
        string DocumentOptionalAdditionalNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull additionalPersonalIdNumber;
        [Export("additionalPersonalIdNumber")]
        string AdditionalPersonalIdNumber { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull issuingAuthority;
        [Export("issuingAuthority")]
        string IssuingAuthority { get; }

        // @property (readonly, nonatomic) MBDriverLicenseDetailedInfo * _Nullable driverLicenseDetailedInfo;
        [NullAllowed, Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }

        // @property (readonly, assign, nonatomic) BOOL empty;
        [Export("empty")]
        bool Empty { get; }
    }

    // @interface MBAdditionalProcessingInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBAdditionalProcessingInfo
    {
    }

    // @interface MBVehicleClassInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVehicleClassInfo
    {
        // @property (readonly, nonatomic) NSString * _Nonnull vehicleClass;
        [Export("vehicleClass")]
        string VehicleClass { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull licenceType;
        [Export("licenceType")]
        string LicenceType { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull effectiveDate;
        [Export("effectiveDate")]
        MBDateResult EffectiveDate { get; }

        // @property (readonly, nonatomic) MBDateResult * _Nonnull expiryDate;
        [Export("expiryDate")]
        MBDateResult ExpiryDate { get; }

        // -(instancetype _Nonnull)initWithVehicleClass:(NSString * _Nonnull)vehicleClass licenceType:(NSString * _Nonnull)licenceType effectiveDate:(MBDateResult * _Nonnull)effectiveDate expiryDate:(MBDateResult * _Nonnull)expiryDate __attribute__((objc_designated_initializer));
        [Export("initWithVehicleClass:licenceType:effectiveDate:expiryDate:")]
        [DesignatedInitializer]
        IntPtr Constructor(string vehicleClass, string licenceType, MBDateResult effectiveDate, MBDateResult expiryDate);
    }
    #endregion


    [BaseType(typeof(NSObject))]
    interface MBImage
    {
        // @property (readonly, nonatomic) UIImage * _Nonnull image;
        [Export("image")]
        UIImage Image { get; }

        // @property (nonatomic) CGRect roi;
        [Export("roi", ArgumentSemantic.Assign)]
        CGRect Roi { get; set; }

        // @property (nonatomic) MBProcessingOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        MBProcessingOrientation Orientation { get; set; }

        // @property (nonatomic) BOOL mirroredHorizontally;
        [Export("mirroredHorizontally")]
        bool MirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL mirroredVertically;
        [Export("mirroredVertically")]
        bool MirroredVertically { get; set; }

        // @property (nonatomic) BOOL estimateFrameQuality;
        [Export("estimateFrameQuality")]
        bool EstimateFrameQuality { get; set; }

        // @property (nonatomic) BOOL cameraFrame;
        [Export("cameraFrame")]
        bool CameraFrame { get; set; }

        // +(instancetype _Nonnull)imageWithUIImage:(UIImage * _Nonnull)image;
        [Static]
        [Export("imageWithUIImage:")]
        MBImage ImageWithUIImage(UIImage image);

        // +(instancetype _Nonnull)imageWithCmSampleBuffer:(CMSampleBufferRef _Nonnull)buffer;
        [Static]
        [Export("imageWithCmSampleBuffer:")]
        unsafe MBImage ImageWithCmSampleBuffer(CMSampleBuffer buffer);

        // +(instancetype _Nonnull)imageWithCvPixelBuffer:(CVPixelBufferRef _Nonnull)buffer orientation:(UIImageOrientation)orientation;
        [Static]
        [Export("imageWithCvPixelBuffer:orientation:")]
        MBImage ImageWithCvPixelBuffer(CVPixelBuffer buffer, UIImageOrientation orientation);
    }

    // typedef void (^MBCaptureHighResImage)(MBImage * _Nullable);
    delegate void MBCaptureHighResImage([NullAllowed] MBImage arg0);

    public interface IMBRecognizerRunnerViewController { }

    // @protocol MBRecognizerRunnerViewController <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewController
    {
        // @required @property (nonatomic) BOOL autorotate;
        [Abstract]
        [Export("autorotate")]
        bool Autorotate { get; set; }

        // @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Abstract]
        [Export("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @required -(void)pauseScanning;
        [Abstract]
        [Export("pauseScanning")]
        void PauseScanning();

        // @required -(BOOL)isScanningPaused;
        [Abstract]
        [Export("isScanningPaused")]
        bool IsScanningPaused { get; }

        // @required -(void)resumeScanningAndResetState:(BOOL)resetState;
        [Abstract]
        [Export("resumeScanningAndResetState:")]
        void ResumeScanningAndResetState(bool resetState);

        // @required -(void)resumeCamera:(void (^ _Nullable)(void))completion;
        [Abstract]
        [Export("resumeCamera:")]
        void ResumeCamera([NullAllowed] Action completion);

        // @required -(BOOL)pauseCamera;
        [Abstract]
        [Export("pauseCamera")]
        bool PauseCamera { get; }

        // @required -(BOOL)isCameraPaused;
        [Abstract]
        [Export("isCameraPaused")]
        bool IsCameraPaused { get; }

        // @required -(void)playScanSuccessSound;
        [Abstract]
        [Export("playScanSuccessSound")]
        void PlayScanSuccessSound();

        // @required -(void)willSetTorchOn:(BOOL)torchOn;
        [Abstract]
        [Export("willSetTorchOn:")]
        void WillSetTorchOn(bool torchOn);

        // @required -(void)resetState;
        [Abstract]
        [Export("resetState")]
        void ResetState();

        // @required -(void)captureHighResImage:(MBCaptureHighResImage _Nonnull)highResoulutionImageCaptured;
        [Abstract]
        [Export("captureHighResImage:")]
        void CaptureHighResImage(MBCaptureHighResImage highResoulutionImageCaptured);
    }

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>;
    public interface IMBOverlayContainerViewController { }

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>
    [Protocol]
    interface MBOverlayContainerViewController : MBRecognizerRunnerViewController
    {
        // @required -(void)overlayViewControllerWillCloseCamera:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerWillCloseCamera:")]
        void OverlayViewControllerWillCloseCamera(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewControllerShouldDisplayTorch:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerShouldDisplayTorch:")]
        bool OverlayViewControllerShouldDisplayTorch(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewController:(MBOverlayViewController *)overlayViewController willSetTorch:(BOOL)isTorchOn;
        [Abstract]
        [Export("overlayViewController:willSetTorch:")]
        bool OverlayViewController(MBOverlayViewController overlayViewController, bool isTorchOn);

        // @required -(BOOL)shouldDisplayHelpButton;
        [Abstract]
        [Export("shouldDisplayHelpButton")]
        bool ShouldDisplayHelpButton { get; }

        // @required -(BOOL)isStatusBarPresented;
        [Abstract]
        [Export("isStatusBarPresented")]
        bool IsStatusBarPresented { get; }

        // @required -(BOOL)isTorchOn;
        [Abstract]
        [Export("isTorchOn")]
        bool IsTorchOn { get; }

        // @required -(BOOL)isCameraAuthorized;
        [Abstract]
        [Export("isCameraAuthorized")]
        bool IsCameraAuthorized { get; }
    }

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>
    [BaseType(typeof(UIViewController))]
    [DisableDefaultCtor]
    [Model, Protocol]
    interface MBOverlayViewController
    {
        // @property (nonatomic, weak) UIViewController<MBOverlayContainerViewController> * _Nullable recognizerRunnerViewController;
        [NullAllowed, Export("recognizerRunnerViewController", ArgumentSemantic.Weak)]
        IMBOverlayContainerViewController RecognizerRunnerViewController { get; set; }
    }

    // @interface MBViewControllerFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface MBViewControllerFactory
    {
        // +(UIViewController<MBRecognizerRunnerViewController> * _Nullable)recognizerRunnerViewControllerWithOverlayViewController:(MBOverlayViewController * _Nonnull)overlayViewController __attribute__((swift_name("recognizerRunnerViewController(withOverlayViewController:)")));
        [Static]
        [Export("recognizerRunnerViewControllerWithOverlayViewController:")]
        IMBRecognizerRunnerViewController RecognizerRunnerViewControllerWithOverlayViewController(MBOverlayViewController overlayViewController);
    }

    // @interface MBBaseOverlayViewController : MBOverlayViewController
    [BaseType(typeof(MBOverlayViewController))]
    interface MBBaseOverlayViewController
    {
        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBRecognizerResult : NSObject

    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerResult
    {
        // @property (readonly, assign, nonatomic) MBRecognizerResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBRecognizerResultState ResultState { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull resultStateString;
        [Export("resultStateString")]
        string ResultStateString { get; }
    }

    // @interface MBEntity : NSObject
    [BaseType(typeof(NSObject))]
    interface MBEntity
    {
    }

    // @interface MBRecognizer : MBEntity
    [BaseType(typeof(MBEntity))]
    interface MBRecognizer
    {
        // @property (readonly, nonatomic, weak) MBRecognizerResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBRecognizerResult BaseResult { get; }

        // -(UIInterfaceOrientationMask)getOptimalHudOrientation;
        [Export("getOptimalHudOrientation")]
        UIInterfaceOrientationMask OptimalHudOrientation { get; }
    }

    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerCollection : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizers:(NSArray<MBRecognizer *> * _Nonnull)recognizers __attribute__((objc_designated_initializer));
        [Export("initWithRecognizers:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer[] recognizers);

        // @property (nonatomic, strong) NSArray<MBRecognizer *> * _Nonnull recognizerList;
        [Export("recognizerList", ArgumentSemantic.Strong)]
        MBRecognizer[] RecognizerList { get; set; }

        // @property (nonatomic) BOOL allowMultipleResults;
        [Export("allowMultipleResults")]
        bool AllowMultipleResults { get; set; }

        // @property (nonatomic) NSTimeInterval partialRecognitionTimeout;
        [Export("partialRecognitionTimeout")]
        double PartialRecognitionTimeout { get; set; }

        // @property (nonatomic) MBRecognitionMode recognitionMode;
        [Export("recognitionMode", ArgumentSemantic.Assign)]
        MBRecognitionMode RecognitionMode { get; set; }

        // @property (nonatomic) MBFrameQualityEstimationMode frameQualityEstimationMode;
        [Export("frameQualityEstimationMode", ArgumentSemantic.Assign)]
        MBFrameQualityEstimationMode FrameQualityEstimationMode { get; set; }
    }

    // @interface MBCameraSettings : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface MBCameraSettings : INSCopying
    {
        // @property (assign, nonatomic) MBCameraPreset cameraPreset;
        [Export("cameraPreset", ArgumentSemantic.Assign)]
        MBCameraPreset CameraPreset { get; set; }

        // @property (assign, nonatomic) MBCameraType cameraType;
        [Export("cameraType", ArgumentSemantic.Assign)]
        MBCameraType CameraType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval autofocusInterval;
        [Export("autofocusInterval")]
        double AutofocusInterval { get; set; }

        // @property (assign, nonatomic) MBCameraAutofocusRestriction cameraAutofocusRestriction;
        [Export("cameraAutofocusRestriction", ArgumentSemantic.Assign)]
        MBCameraAutofocusRestriction CameraAutofocusRestriction { get; set; }

        // @property (nonatomic, weak) NSString * videoGravity;
        [Export("videoGravity", ArgumentSemantic.Weak)]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) CGPoint focusPoint;
        [Export("focusPoint", ArgumentSemantic.Assign)]
        CGPoint FocusPoint { get; set; }

        // @property (nonatomic) BOOL cameraMirroredHorizontally;
        [Export("cameraMirroredHorizontally")]
        bool CameraMirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL cameraMirroredVertically;
        [Export("cameraMirroredVertically")]
        bool CameraMirroredVertically { get; set; }

        // @property (nonatomic) CGFloat previewZoomScale;
        [Export("previewZoomScale")]
        nfloat PreviewZoomScale { get; set; }

        // -(NSString *)calcSessionPreset;
        [Export("calcSessionPreset")]
        string CalcSessionPreset { get; }

        // -(AVCaptureAutoFocusRangeRestriction)calcAutofocusRangeRestriction;
        [Export("calcAutofocusRangeRestriction")]
        AVCaptureAutoFocusRangeRestriction CalcAutofocusRangeRestriction { get; }
    }

    // @interface MBOverlaySettings : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface MBOverlaySettings : INSCopying
    {
        // @property (nonatomic, strong) NSString * _Nullable language;
        [NullAllowed, Export("language", ArgumentSemantic.Strong)]
        string Language { get; set; }

        // @property (nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; set; }
    }

    // @interface MBBaseOverlaySettings : MBOverlaySettings
    [BaseType(typeof(MBOverlaySettings))]
    interface MBBaseOverlaySettings
    {
        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Export("supportedOrientations")]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable soundFilePath;
        [NullAllowed, Export("soundFilePath", ArgumentSemantic.Strong)]
        string SoundFilePath { get; set; }

        // @property (assign, nonatomic) BOOL displayCancelButton;
        [Export("displayCancelButton")]
        bool DisplayCancelButton { get; set; }

        // @property (assign, nonatomic) BOOL displayTorchButton;
        [Export("displayTorchButton")]
        bool DisplayTorchButton { get; set; }
    }

    // @interface MBBlinkIdOverlaySettings : MBBaseOverlaySettings
    [Introduced(PlatformName.iOS, 8, 0)]
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBlinkIdOverlaySettings
    {
        // @property (assign, nonatomic) BOOL requireDocumentSidesDataMatch;
        [Export("requireDocumentSidesDataMatch")]
        bool RequireDocumentSidesDataMatch { get; set; }

        // @property (assign, nonatomic) BOOL showNotSupportedDialog;
        [Export("showNotSupportedDialog")]
        bool ShowNotSupportedDialog { get; set; }

        // @property (assign, nonatomic) BOOL showFlashlightWarning;
        [Export("showFlashlightWarning")]
        bool ShowFlashlightWarning { get; set; }

        // @property (assign, nonatomic) NSTimeInterval backSideScanningTimeout;
        [Export("backSideScanningTimeout")]
        double BackSideScanningTimeout { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull firstSideInstructionsText;
        [Export("firstSideInstructionsText", ArgumentSemantic.Strong)]
        string FirstSideInstructionsText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull scanBarcodeText;
        [Export("scanBarcodeText", ArgumentSemantic.Strong)]
        string ScanBarcodeText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull flipInstructions;
        [Export("flipInstructions", ArgumentSemantic.Strong)]
        string FlipInstructions { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMoveCloser;
        [Export("errorMoveCloser", ArgumentSemantic.Strong)]
        string ErrorMoveCloser { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMoveFarther;
        [Export("errorMoveFarther", ArgumentSemantic.Strong)]
        string ErrorMoveFarther { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorDocumentTooCloseToEdge;
        [Export("errorDocumentTooCloseToEdge", ArgumentSemantic.Strong)]
        string ErrorDocumentTooCloseToEdge { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingTitle;
        [Export("sidesNotMatchingTitle", ArgumentSemantic.Strong)]
        string SidesNotMatchingTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull sidesNotMatchingMessage;
        [Export("sidesNotMatchingMessage", ArgumentSemantic.Strong)]
        string SidesNotMatchingMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull dataMismatchTitle;
        [Export("dataMismatchTitle", ArgumentSemantic.Strong)]
        string DataMismatchTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull dataMismatchMessage;
        [Export("dataMismatchMessage", ArgumentSemantic.Strong)]
        string DataMismatchMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentTitle;
        [Export("unsupportedDocumentTitle", ArgumentSemantic.Strong)]
        string UnsupportedDocumentTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull unsupportedDocumentMessage;
        [Export("unsupportedDocumentMessage", ArgumentSemantic.Strong)]
        string UnsupportedDocumentMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutTitle;
        [Export("recognitionTimeoutTitle", ArgumentSemantic.Strong)]
        string RecognitionTimeoutTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recognitionTimeoutMessage;
        [Export("recognitionTimeoutMessage", ArgumentSemantic.Strong)]
        string RecognitionTimeoutMessage { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull retryButtonText;
        [Export("retryButtonText", ArgumentSemantic.Strong)]
        string RetryButtonText { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull errorMandatoryFieldMissing;
        [Export("errorMandatoryFieldMissing", ArgumentSemantic.Strong)]
        string ErrorMandatoryFieldMissing { get; set; }
    }

    // @protocol MBBlinkIdOverlayViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBBlinkIdOverlayViewControllerDelegate
    {
        // @required -(void)blinkIdOverlayViewControllerDidFinishScanning:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController state:(MBRecognizerResultState)state;
        [Abstract]
        [Export("blinkIdOverlayViewControllerDidFinishScanning:state:")]
        void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController blinkIdOverlayViewController, MBRecognizerResultState state);

        // @required -(void)blinkIdOverlayViewControllerDidTapClose:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Abstract]
        [Export("blinkIdOverlayViewControllerDidTapClose:")]
        void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController blinkIdOverlayViewController);

        // @optional -(void)blinkIdOverlayViewControllerDidFinishScanningFirstSide:(MBBlinkIdOverlayViewController * _Nonnull)blinkIdOverlayViewController;
        [Export("blinkIdOverlayViewControllerDidFinishScanningFirstSide:")]
        void BlinkIdOverlayViewControllerDidFinishScanningFirstSide(MBBlinkIdOverlayViewController blinkIdOverlayViewController);
    }

    // @interface MBBlinkIdOverlayViewController : MBBaseOverlayViewController
    [BaseType(typeof(MBBaseOverlayViewController))]
    interface MBBlinkIdOverlayViewController
    {
        // @property (readonly, nonatomic) MBBlinkIdOverlaySettings * _Nonnull settings;
        [Export("settings")]
        MBBlinkIdOverlaySettings Settings { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBBlinkIdOverlayViewControllerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<MBBlinkIdOverlayViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        // -(instancetype _Nonnull)initWithSettings:(MBBlinkIdOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBlinkIdOverlayViewControllerDelegate> _Nonnull)delegate;
        [Export("initWithSettings:recognizerCollection:delegate:")]
        IntPtr Constructor(MBBlinkIdOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBlinkIdOverlayViewControllerDelegate @delegate);
    }

    // @interface MBBlinkIdMultiSideRecognizerResult : MBRecognizerResult<NSCopying, MBCombinedRecognizerResult, MBFaceImageResult, MBEncodedFaceImageResult, MBCombinedFullDocumentImageResult, MBEncodedCombinedFullDocumentImageResult, MBAgeResult, MBDocumentExpirationCheckResult, MBSignatureImageResult, MBEncodedSignatureImageResult>
    [BaseType(typeof(MBRecognizer))]
    interface MBBlinkIdMultiSideRecognizerResult :
        INSCopying,
        IMBCombinedRecognizerResult,
        IMBFaceImageResult,
        IMBEncodedFaceImageResult,
        IMBCombinedFullDocumentImageResult,
        IMBEncodedCombinedFullDocumentImageResult,
        IMBAgeResult,
        IMBDocumentExpirationCheckResult,
        IMBSignatureImageResult,
        IMBEncodedSignatureImageResult
    {
        // @property(nonatomic, readonly, nullable) MBStringResult* address;
        [Export("address")]
        MBStringResult? Uncertain { get; }

        // @property(nonatomic, readonly, nullable) MBDateResult* dateOfBirth;
        [Export("dateOfBirth")]
        MBDateResult? DateOfBirth { get; }

        // @property(nonatomic, readonly, nullable) MBDateResult* dateOfExpiry;
        [Export("dateOfExpiry")]
        MBDateResult? DateOfExpiry { get; }

        // @property(nonatomic, readonly, nullable) MBDateResult* dateOfIssue;
        [Export("dateOfIssue")]
        MBDateResult? DateOfIssue { get; }

        // @property(nonatomic, readonly) BOOL dateOfExpiryPermanent;
        [Export("dateOfExpiryPermanent")]
        bool DateOfExpiryPermanent { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* documentNumber;
        [Export("documentNumber")]
        MBStringResult? DocumentNumber { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* firstName;
        [Export("firstName")]
        MBStringResult? FirstName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* fullName;
        [Export("fullName")]
        MBStringResult? FullName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* lastName;
        [Export("lastName")]
        MBStringResult? LastName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* fathersName;
        [Export("fathersName")]
        MBStringResult? FathersName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* mothersName;
        [Export("mothersName")]
        MBStringResult? MothersName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* sex;
        [Export("sex")]
        MBStringResult? Sex { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* localizedName;
        [Export("localizedName")]
        MBStringResult? LocalizedName { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* additionalNameInformation;
        [Export("additionalNameInformation")]
        MBStringResult? AdditionalNameInformation { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* additionalAddressInformation;
        [Export("additionalAddressInformation")]
        MBStringResult? AdditionalAddressInformation { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* additionalOptionalAddressInformation;
        [Export("additionalOptionalAddressInformation")]
        MBStringResult? AdditionalOptionalAddressInformation { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* placeOfBirth;
        [Export("placeOfBirth")]
        MBStringResult? PlaceOfBirth { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* nationality;
        [Export("nationality")]
        MBStringResult? Nationality { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* race;
        [Export("race")]
        MBStringResult? Race { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* religion;
        [Export("religion")]
        MBStringResult? Religion { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* profession;
        [Export("profession")]
        MBStringResult? Profession { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* maritalStatus;
        [Export("maritalStatus")]
        string? MaritalStatus { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* residentialStatus;
        [Export("residentialStatus")]
        MBStringResult? ResidentialStatus { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* employer;
        [Export("employer")]
        MBStringResult? Employer { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* personalIdNumber;
        [Export("personalIdNumber")]
        MBStringResult? PersonalIdNumber { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* documentAdditionalNumber;
        [Export("documentAdditionalNumber")]
        MBStringResult? DocumentAdditionalNumber { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* documentOptionalAdditionalNumber;
        [Export("documentOptionalAdditionalNumber")]
        MBStringResult? DocumentOptionalAdditionalNumber { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* issuingAuthority;
        [Export("issuingAuthority")]
        MBStringResult? IssuingAuthority { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* sponsor;
        [Export("sponsor")]
        MBStringResult? Sponsor { get; }

        // @property(nonatomic, readonly, nullable) MBStringResult* bloodType;
        [Export("bloodType")]
        MBStringResult? BloodType { get; }

        // @property(nonatomic, readonly, nullable) MBMrzResult* mrzResult;
        [Export("mrzResult")]
        MBMrzResult? MrzResult { get; }

        // @property(nonatomic, readonly, nullable) MBDriverLicenseDetailedInfo* driverLicenseDetailedInfo;
        [Export("driverLicenseDetailedInfo")]
        MBDriverLicenseDetailedInfo? DriverLicenseDetailedInfo { get; }

        // @property(nonatomic, readonly, nullable) MBClassInfo* classInfo;
        [Export("classInfo")]
        MBClassInfo? ClassInfo { get; }

        // @property(nonatomic, readonly, nullable) MBImageAnalysisResult* frontImageAnalysisResult;
        [Export("frontImageAnalysisResult")]
        MBImageAnalysisResult? FrontImageAnalysisResult { get; }

        // @property(nonatomic, readonly, nullable) MBImageAnalysisResult* backImageAnalysisResult;
        [Export("backImageAnalysisResult")]
        MBImageAnalysisResult? BackImageAnalysisResult { get; }

        // @property(nonatomic, readonly, nullable) MBBarcodeResult* barcodeResult;
        [Export("barcodeResult")]
        MBBarcodeResult? BarcodeResult { get; }

        // @property(nonatomic, readonly, nullable) MBVizResult* frontVizResult;
        [Export("frontVizResult")]
        MBVizResult? FrontVizResult { get; }

        // @property(nonatomic, readonly, nullable) MBVizResult* backVizResult;
        [Export("backVizResult")]
        MBVizResult? BackVizResult { get; }

        // property(nonatomic, readonly, assign) MBProcessingStatus processingStatus;
        [Export("processingStatus")]
        MBProcessingStatus ProcessingStatus { get; }

        // @property(nonatomic, readonly, assign) MBProcessingStatus frontProcessingStatus;
        [Export("frontProcessingStatus")]
        MBProcessingStatus FrontProcessingStatus { get; }

        // @property(nonatomic, readonly, assign) MBProcessingStatus backProcessingStatus;
        [Export("backProcessingStatus")]
        MBProcessingStatus BackProcessingStatus { get; }

        // @property(nonatomic, readonly, nullable) MBAdditionalProcessingInfo* frontAdditionalProcessingInfo;
        [Export("frontAdditionalProcessingInfo")]
        MBAdditionalProcessingInfo? FrontAdditionalProcessingInfo { get; }

        // @property(nonatomic, readonly, nullable) MBAdditionalProcessingInfo* backAdditionalProcessingInfo;
        [Export("backAdditionalProcessingInfo")]
        MBAdditionalProcessingInfo? BackAdditionalProcessingInfo { get; }

        // @property(nonatomic, readonly, assign) MBRecognitionMode recognitionMode;
        [Export("recognitionMode")]
        MBRecognitionMode RecognitionMode { get; }

        // @property(nonatomic, readonly, nullable) MBImage* frontCameraFrame;
        [Export("frontCameraFrame")]
        MBImage FrontCameraFrame { get; }

        // @property(nonatomic, readonly, nullable) MBImage* backCameraFrame;
        [Export("backCameraFrame")]
        MBImage BackCameraFrame { get; }

        // @property(nonatomic, readonly, nullable) MBImage* barcodeCameraFrame;
        [Export("barcodeCameraFrame")]
        MBImage BarcodeCameraFrame { get; }

        // @property(nonatomic, readonly, nullable) MBDataMatchResult* dataMatchResult;
        [Export("dataMatchResult")]
        MBDataMatchResult DataMatchResult { get; }

        // @property(nonatomic, readonly) CGRect faceImageLocation;
        [Export("faceImageLocation")]
        CGRect FaceImageLocation { get; }

        // @property(nonatomic, readonly) MBSide faceImageSide;
        [Export("faceImageSide")]
        MBSide FaceImageSide { get; }
    }

    // @interface MBBlinkIdMultiSideRecognizer : MBRecognizer<NSCopying, MBCombinedRecognizer, MBFaceImage, MBEncodeFaceImage, MBFaceImageDpi, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageDpi, MBFullDocumentImageExtensionFactors, MBSignatureImage, MBSignatureImageDpi, MBEncodeSignatureImage, MBCameraFrames, MBClassAnonymization>
    [BaseType(typeof(MBRecognizer))]
    interface MBBlinkIdMultiSideRecognizer : INSCopying
    {
        // @property(nonatomic, strong, readonly) MBBlinkIdMultiSideRecognizerResult* result;
        [Export("result", ArgumentSemantic.Strong)]
        MBBlinkIdMultiSideRecognizerResult Result { get; }
    }
}
